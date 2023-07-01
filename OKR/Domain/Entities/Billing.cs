using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageCore.Domain.Entities
{
    public class Billing
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime BillingDate { get; set; }
        public string PaymentsInfo { get; set; }
    }
}
