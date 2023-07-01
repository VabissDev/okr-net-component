using StorageCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageCore.Domain.Abstraction
{
    public interface ISubscriptionRepository
    {
        void Add(Subscription subscription);
        void Update(Subscription subscription);
        IList<Subscription> Get();
        Subscription Get(int id);
    }
}
