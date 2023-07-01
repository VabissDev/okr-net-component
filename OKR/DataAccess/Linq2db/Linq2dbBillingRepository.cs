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
    public class Linq2dbBillingRepository : IBillingRepository
    {
        private readonly OkrDbConnection _okrDbConnection;

        public Linq2dbBillingRepository(OkrDbConnection okrDbConnection)
        {
            _okrDbConnection = okrDbConnection;
        }
        public int Add(Billing obj)
        {
            obj.Id = _okrDbConnection.InsertWithInt32Identity(obj);

            return obj.Id;
        }

        public void Delete(int id)
        {
            _okrDbConnection.Billings
                .Where(x => x.Id == id)
                .Delete();
        }

        public Billing FindById(object id)
        {
            return _okrDbConnection.Billings
                .FirstOrDefault(x => x.Id == (int)id);
        }

        public IList<Billing> Get()
        {
            return _okrDbConnection.Billings.ToList();
        }

        public void Update(Billing billing)
        {
            _okrDbConnection.Update(billing);
        }
    }
}
