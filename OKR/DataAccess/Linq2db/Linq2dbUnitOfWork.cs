using StorageCore.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageCore.DataAccess.Linq2db
{
    public class Linq2dbUnitOfWork : IUnitOfWork
    {
        private readonly OkrDbConnection _okrDbConnection;

        public Linq2dbUnitOfWork(OkrDbConnection okrDbConnection)
        {
            _okrDbConnection = okrDbConnection;
        }
        public ISubscriptionRepository SubscriptionRepository => new Linq2dbSubscriptionRepository(_okrDbConnection);

        public IBillingRepository BillingRepository => new Linq2dbBillingRepository(_okrDbConnection);

        public ISubscriptionPlanRepository SubscriptionPlanRepository => new Linq2dbSubscriptionPlanRepository(_okrDbConnection);

        public void Dispose()
        {
        }
    }
}
