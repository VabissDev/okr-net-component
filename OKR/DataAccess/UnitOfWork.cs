using StorageCore.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageCore.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbService _dbService;

        public UnitOfWork(DbService dbService)
        {
            _dbService = dbService;
        }
        public ISubscriptionRepository SubscriptionRepository => new SubscriptionRepository(_dbService);

        //public IBillingRepository BillingRepository => new BillingRepository(_dbService);

        //public ISubscriptionPlanRepository SubscriptionPlanRepository => new SubscriptionPlanRepository(_dbService);

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
