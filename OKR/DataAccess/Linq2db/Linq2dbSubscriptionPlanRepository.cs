using LinqToDB;
using StorageCore.Domain.Abstraction;
using StorageCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageCore.DataAccess.Linq2db
{
    public class Linq2dbSubscriptionPlanRepository : ISubscriptionPlanRepository
    {
        private readonly OkrDbConnection _okrDbConnection;

        public Linq2dbSubscriptionPlanRepository(OkrDbConnection okrDbConnection)
        {
            _okrDbConnection = okrDbConnection;
        }
        public int Add(SubscriptionPlan obj)
        {
            obj.Id = _okrDbConnection.InsertWithInt32Identity(obj);

            return obj.Id;
        }

        public void Delete(int id)
        {
            _okrDbConnection.SubscriptionPlans
               .Where(x => x.Id == id)
               .Delete();
        }

        public SubscriptionPlan FindById(object id)
        {
            return _okrDbConnection.SubscriptionPlans.LoadWith(x => x.Subscription)
                .FirstOrDefault(x => x.Id == (int)id);
        }

        public IList<SubscriptionPlan> Get()
        {
            return _okrDbConnection.SubscriptionPlans.LoadWith(x => x.Subscription).ToList();
        }

        public SubscriptionPlan GetSubscriptionId(int subscriptionId)
        {
            return _okrDbConnection.SubscriptionPlans
                .LoadWith(x => x.Subscription)
                .FirstOrDefault(x => x.SubscriptionId == subscriptionId);
        }

        public void Update(SubscriptionPlan plan)
        {
            _okrDbConnection.Update(plan);
        }
    }
}
