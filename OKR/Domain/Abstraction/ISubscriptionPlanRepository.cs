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
        Task<bool> Update(SubscriptionPlan obj);
    }
}
