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
    public class SubscriptionPlanService : ISubscriptionPlanService
    {
        private readonly ISubscriptionPlanRepository _db;

        public SubscriptionPlanService(ISubscriptionPlanRepository db)
        {
            _db = db;
        }

        public async Task<bool> Update(int id, UpdateSubscriptionPlanModel model)
        {
            var subscriptionplanModel = await _db.GetById(id);
            if (subscriptionplanModel != null)
            {
                subscriptionplanModel.Amount = model.Amount;
                subscriptionplanModel.Type = model.Type;
                subscriptionplanModel.UserCount = model.UserCount;
                subscriptionplanModel.WorkspaceCount = model.WorkspaceCount;
                subscriptionplanModel.SubscriptionId= model.SubscriptionId;
            }
            var result = await _db.Update(subscriptionplanModel);
            return result;
        }

        public async Task<bool> Add(SubscriptionPlanModel model)
        {
            var subscriptionPlan = new SubscriptionPlan
            {
                Id = model.Id,
                Amount = model.Amount,
                Type = model.Type,
                UserCount = model.UserCount,
                WorkspaceCount = model.WorkspaceCount,
                SubscriptionId = model.SubscriptionId,
        };
            var result = await _db.Create(subscriptionPlan);
            return result;
        }

        public async Task<List<SubscriptionPlan>> Get()
        {
            var result = await _db.GetAll();
            return result;
        }

        public async Task<SubscriptionPlan> GetById(int id)
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
