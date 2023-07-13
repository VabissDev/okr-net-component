using StorageCore.Domain.Abstraction;
using StorageCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageCore.DataAccess
{
    public class BillingRepository : IBillingRepository
    {
        private readonly IDbService _dbService;

        public BillingRepository(IDbService dbService)
        {
            _dbService = dbService;
        }

        public async Task<bool> Create(Billing billing)
        {
            var result = await _dbService.EditData(
                "INSERT INTO billing (id, amount, billing_date, payments_info) VALUES (@id, @amount, @billing_date, @payments_info)",
                new
                {
                    id = billing.Id,
                    amount = billing.Amount,
                    billing_date = billing.BillingDate,
                    payments_info = billing.PaymentsInfo
                });
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var deleteBilling = await _dbService.EditData("DELETE FROM billing WHERE id = @id", new { id });
            return true;
        }

        public async Task<Billing> GetById(int id)
        {
            var billing = await _dbService.GetAsync<Billing>("SELECT * FROM billing WHERE id = @id", new { id });
            return billing;
        }

        public async Task<List<Billing>> GetAll()
        {
            var billings = await _dbService.GetAll<Billing>("SELECT * FROM billing", new { });
            return billings;
        }

        public async Task<Billing> Update(Billing billing)
        {
            var updateSubscription = await _dbService.EditData(
           "UPDATE billing SET amount = @amount, billing_date = @billing_date::timestamp, payments_info = @payments_info WHERE id = @id",
           new
           {
               id = billing.Id,
               amount = billing.Amount,
               billing_date = billing.BillingDate,
               payments_info = billing.PaymentsInfo
           });
            return billing;
        }
    }
}
