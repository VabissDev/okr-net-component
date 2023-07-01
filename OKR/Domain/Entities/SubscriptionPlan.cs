using StorageCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageCore.Domain.Entities
{
    public class SubscriptionPlan
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public PlanType Type { get; set; }
        public Subscription SubscriptionId { get; set; }
        public int UserCount { get; set; }
        public int WorkspaceCount { get; set; }
    }
}
