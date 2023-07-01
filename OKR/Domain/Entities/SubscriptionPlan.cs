using LinqToDB.Mapping;
using StorageCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageCore.Domain.Entities
{
    [Table("SubscriptionPlans")]
    public class SubscriptionPlan
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }
        [Column]
        public decimal Amount { get; set; }
        [Column]
        public PlanType Type { get; set; }
        [Column]
        public int SubscriptionId { get; set; }
        [Association(ThisKey = "SubscriptionId", OtherKey = "Id")]
        public Subscription Subscription { get; set; }
        [Column]
        public int UserCount { get; set; }
        [Column]
        public int WorkspaceCount { get; set; }
    }
}
