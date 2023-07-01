using StorageCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageCore.Domain.Abstraction
{
    public interface ISubscriptionPlanRepository
    {
        void Add(SubscriptionPlan plan);
        void Update(SubscriptionPlan plan);
        IList<SubscriptionPlan> Get();
        SubscriptionPlan Get(int id);
        SubscriptionPlan GetSubscriptionId(int substriptionId);
    }
}
