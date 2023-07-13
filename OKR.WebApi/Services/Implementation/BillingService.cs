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
    public class BillingService : IBillingService
    {
        private readonly IBillingRepository _db;

        public BillingService(IBillingRepository db)
        {
            _db = db;
        }

        public async Task<Billing> Update(int id, UpdateBillingModel model)
        {
            var billingModel = await _db.GetById(id);
            if (billingModel != null)
            {
                billingModel.Amount = model.Amount;
                billingModel.BillingDate = model.BillingDate;
                billingModel.PaymentsInfo = model.PaymentsInfo;
            }
            var result = await _db.Update(billingModel);
            return result;
        }

        public async Task<bool> Add(BillingModel model)
        {
            var billing = new Billing
            {
                Id = model.Id,
                Amount = model.Amount,
                BillingDate = model.BillingDate,
                PaymentsInfo = model.PaymentsInfo
            };
            var result = await _db.Create(billing);
            return result;
        }

        public async Task<List<Billing>> Get()
        {
            var result = await _db.GetAll();
            return result;
        }

        public async Task<Billing> GetById(int id)
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
