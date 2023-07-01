using StorageCore.DataAccess.Linq2db;
using StorageCore.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageCore.DataAccess
{
    internal static class UnitOfWorkFactory
    {
        internal static IUnitOfWork CreateUnitOfWork(OkrDbConnection okrDbConnection)
        {
            return new Linq2dbUnitOfWork(okrDbConnection);
        }
    }
}
