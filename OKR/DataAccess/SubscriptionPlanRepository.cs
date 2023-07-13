using Dapper;
using Npgsql;
using StorageCore.Domain.Abstraction;
using StorageCore.Domain.Entities;
using StorageCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageCore.DataAccess
{
    public class SubscriptionPlanRepository : ISubscriptionPlanRepository
    {
        private readonly IDbConnection _connection;

        public SubscriptionPlanRepository(IDbConnection connection)
        {
            
            _connection = connection;
            NpgsqlConnection.GlobalTypeMapper.MapEnum<PlanType>();
        }

        public async Task<bool> Create(SubscriptionPlan obj)
        {
            using (var connection = new NpgsqlConnection("Server=localhost; Port=5432; Username=postgres; Password=Thdy43qkvf72?; Database=OkrApp"))
            {
                connection.Open();

                NpgsqlConnection.GlobalTypeMapper.MapEnum<PlanType>();

                var command = new NpgsqlCommand("INSERT INTO subscription_plan (id, amount, type, user_count, workspace_count, sub_id) " +
                                                "VALUES (@id, @amount, @type::integer, @user_count, @workspace_count, @sub_id)", connection);

                command.Parameters.AddWithValue("id", obj.Id);
                command.Parameters.AddWithValue("amount", obj.Amount);
                command.Parameters.AddWithValue("type", (int)obj.Type);
                command.Parameters.AddWithValue("user_count", obj.UserCount);
                command.Parameters.AddWithValue("workspace_count", obj.WorkspaceCount);
                command.Parameters.AddWithValue("sub_id", obj.SubscriptionId);

                await command.ExecuteNonQueryAsync();
            }

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            using (var connection = new NpgsqlConnection("Server=localhost; Port=5432; Username=postgres; Password=Thdy43qkvf72?; Database=OkrApp"))
            {
                connection.Open();

                var command = new NpgsqlCommand("DELETE FROM subscription_plan WHERE id = @id", connection);
                command.Parameters.AddWithValue("id", id);

                await command.ExecuteNonQueryAsync();
            }

            return true;
        }

        public async Task<List<SubscriptionPlan>> GetAll()
        {
            var query = @"SELECT sp.*, s.* 
                          FROM subscription_plan sp 
                          JOIN subscription s ON sp.sub_id = s.id";

            using (var multi = await _connection.QueryMultipleAsync(query))
            {
                var subscriptionPlans = multi.Read<SubscriptionPlan, Subscription, SubscriptionPlan>(
                    (subscriptionPlan, subscription) =>
                    {
                        subscriptionPlan.Subscription = subscription;
                        subscriptionPlan.SubscriptionId = subscription.Id;
                        return subscriptionPlan;
                    },
                    splitOn: "id"
                );

                return subscriptionPlans.ToList();
            }
        }

        public async Task<SubscriptionPlan> GetById(int id)
        {
            var query = @"SELECT sp.*, s.* 
                          FROM subscription_plan sp 
                          JOIN subscription s ON sp.sub_id = s.id
                          WHERE sp.id = @id";

            var subscriptionPlans = await _connection.QueryAsync<SubscriptionPlan, Subscription, SubscriptionPlan>(
                query,
                (subscriptionPlan, subscription) =>
                {
                    subscriptionPlan.Subscription = subscription;
                    subscriptionPlan.SubscriptionId = subscription.Id;
                    return subscriptionPlan;
                },
                new { id },
                splitOn: "id"
            );

            return subscriptionPlans.FirstOrDefault();
        }

        public async Task<bool> Update(SubscriptionPlan obj)
        {
            using (var connection = new NpgsqlConnection("Server=localhost; Port=5432; Username=postgres; Password=Thdy43qkvf72?; Database=OkrApp"))
            {
                connection.Open();

                var command = new NpgsqlCommand("UPDATE subscription_plan " +
                                                "SET amount = @amount, type = @type::integer, user_count = @user_count, " +
                                                "workspace_count = @workspace_count, sub_id = @sub_id " +
                                                "WHERE id = @id", connection);

                command.Parameters.AddWithValue("id", obj.Id);
                command.Parameters.AddWithValue("amount", obj.Amount);
                command.Parameters.AddWithValue("type", (int)obj.Type);
                command.Parameters.AddWithValue("user_count", obj.UserCount);
                command.Parameters.AddWithValue("workspace_count", obj.WorkspaceCount);
                command.Parameters.AddWithValue("sub_id", obj.SubscriptionId);

                await command.ExecuteNonQueryAsync();
            }

            return true;
        }

        Task<SubscriptionPlan> IRepository<SubscriptionPlan>.Update(SubscriptionPlan obj)
        {
            throw new NotImplementedException();
        }
    }
}
