using OKR.WebApi.Models;
using StorageCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OKR.WebApi.Services.Abstraction
{
    public interface ISubscriptionService
    {
        Task<Subscription> Update(int id, UpdateSubscriptionModel model);
        Task<bool> Add(SubscriptionModel model);
        Task<List<Subscription>> Get();
        Task<Subscription> GetById(int id);
        Task<bool> Delete(int id);
    }
}
