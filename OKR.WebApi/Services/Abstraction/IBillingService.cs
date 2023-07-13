using OKR.WebApi.Models;
using StorageCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OKR.WebApi.Services.Abstraction
{
    public interface IBillingService
    {
        Task<Billing> Update(int id, UpdateBillingModel model);
        Task<bool> Add(BillingModel model);
        Task<List<Billing>> Get();
        Task<Billing> GetById(int id);
        Task<bool> Delete(int id);
    }
}
