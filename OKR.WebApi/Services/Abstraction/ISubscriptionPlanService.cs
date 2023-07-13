using OKR.WebApi.Models;
using StorageCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OKR.WebApi.Services.Abstraction
{
    public interface ISubscriptionPlanService
    {
        Task<bool> Update(int id, UpdateSubscriptionPlanModel model);
        Task<bool> Add(SubscriptionPlanModel model);
        Task<List<SubscriptionPlan>> Get();
        Task<SubscriptionPlan> GetById(int id);
        Task<bool> Delete(int id);
    }
}
