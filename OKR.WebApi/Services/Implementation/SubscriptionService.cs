using OKR.WebApi.Models;
using OKR.WebApi.Services.Abstraction;
using StorageCore.Domain.Abstraction;
using StorageCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OKR.WebApi.Services.Implementation
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _db;

        public SubscriptionService(ISubscriptionRepository db)
        {
            _db = db;
        }

        public async Task<Subscription> Update(int id, UpdateSubscriptionModel model)
        {
            var subscriptionModel = await _db.GetById(id);
            if (subscriptionModel != null)
            {
                subscriptionModel.StartTime = model.StartTime;
                subscriptionModel.EndTime = model.EndTime;
                subscriptionModel.Active = model.Active;
            }
            var result = await _db.Update(subscriptionModel);
            return result;
        }

        public async Task<bool> Add(SubscriptionModel model)
        {
            var subscription = new Subscription
            {
                Id = model.Id,
                StartTime = model.StartTime,
                EndTime = model.EndTime,
                Active = model.Active
            };
            var result = await _db.Create(subscription);
            return result;
        }

        public async Task<List<Subscription>> Get()
        {
            var result = await _db.GetAll();
            return result;
        }

        public async Task<Subscription> GetById(int id)
        {
            var result = await _db.GetById(id);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _db.Delete(id);
            return result;
        }
    }
}
