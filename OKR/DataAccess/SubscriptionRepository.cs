using StorageCore.Domain.Abstraction;
using StorageCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageCore.DataAccess
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly IDbService _dbService;

        public SubscriptionRepository(IDbService dbService)
        {
            _dbService = dbService;
        }

        public async Task<bool> Create(Subscription subscription)
        {
            var result = await _dbService.EditData(
                "INSERT INTO subscription (id, start_time, end_time, active) VALUES (@id, @start_time, @end_time, @active)",
                new
                {
                    id=subscription.Id,
                    start_time = subscription.StartTime,
                    end_time = subscription.EndTime,
                    active = subscription.Active
                });
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var deleteSubscription = await _dbService.EditData("DELETE FROM subscription WHERE id = @id", new { id });
            return true;
        }

        public async Task<Subscription> GetById(int id)
        {
            var subscription = await _dbService.GetAsync<Subscription>("SELECT * FROM subscription WHERE id = @id", new { id });
            return subscription;
        }

        public async Task<List<Subscription>> GetAll()
        {
            var subscriptions = await _dbService.GetAll<Subscription>("SELECT * FROM subscription", new { });
            return subscriptions;
        }

        public async Task<Subscription> Update(Subscription subscription)
        {
            var updateSubscription = await _dbService.EditData(
           "UPDATE subscription SET start_time = @start_time::timestamp, end_time = @end_time::timestamp, active = @active WHERE id = @id",
           new
           {
               start_time = subscription.StartTime.ToString("yyyy-MM-dd HH:mm:ss"),
               end_time = subscription.EndTime.ToString("yyyy-MM-dd HH:mm:ss"),
               active = subscription.Active,
               id = subscription.Id
           });
            return subscription;
        }
    }
}
