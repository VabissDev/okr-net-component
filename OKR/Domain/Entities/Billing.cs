using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageCore.Domain.Entities
{
    [Table("Billings")]
    public class Billing
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }
        [Column]
        public decimal Amount { get; set; }
        [Column]
        public DateTime BillingDate { get; set; }
        [Column]
        public string PaymentsInfo { get; set; }
    }
}
