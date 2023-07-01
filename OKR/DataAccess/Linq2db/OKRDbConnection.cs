using LinqToDB;
using LinqToDB.Data;
using StorageCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageCore.DataAccess.Linq2db
{
    public class OkrDbConnection : DataConnection
    {
        public OkrDbConnection(DataOptions options) : base(options)
        {
        }
        public ITable<Subscription> Subscriptions => this.GetTable<Subscription>();
        public ITable<Billing> Billings => this.GetTable<Billing>();
        public ITable<SubscriptionPlan> SubscriptionPlans => this.GetTable<SubscriptionPlan>();
    }
}
