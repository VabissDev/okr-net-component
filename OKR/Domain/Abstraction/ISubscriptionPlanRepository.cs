using StorageCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageCore.Domain.Abstraction
{
    public interface ISubscriptionPlanRepository : IRepository<SubscriptionPlan>
    {
        void Update(SubscriptionPlan plan);
        IList<SubscriptionPlan> Get();
        void Delete(int id);
        SubscriptionPlan GetSubscriptionId(int subscriptionId);
    }
}
