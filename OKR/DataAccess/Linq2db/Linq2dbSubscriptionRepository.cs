using LinqToDB;
using StorageCore.Domain.Abstraction;
using StorageCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageCore.DataAccess.Linq2db
{
    public class Linq2dbSubscriptionRepository : ISubscriptionRepository
    {
        private readonly OkrDbConnection _okrDbConnection;

        public Linq2dbSubscriptionRepository(OkrDbConnection okrDbConnection)
        {
            _okrDbConnection = okrDbConnection;
        }

        public int Add(Subscription obj)
        {
            obj.Id = _okrDbConnection.InsertWithInt32Identity(obj);

            return obj.Id;
        }

        public void Delete(int id)
        {
            _okrDbConnection.Subscriptions
                .Where(x => x.Id == id)
                .Delete();
        }

        public Subscription FindById(object id)
        {
            return _okrDbConnection.Subscriptions
                .FirstOrDefault(x => x.Id == (int)id);
        }

        public IList<Subscription> Get()
        {
            return _okrDbConnection.Subscriptions.ToList();
        }

        public void Update(Subscription subscription)
        {
            _okrDbConnection.Update(subscription);
        }
    }
}
