using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageCore.Domain.Abstraction
{
    public interface IUnitOfWork : IDisposable
    {
        ISubscriptionRepository SubscriptionRepository { get; }
        //IBillingRepository BillingRepository { get; }
        //ISubscriptionPlanRepository SubscriptionPlanRepository { get; }
    }
}
