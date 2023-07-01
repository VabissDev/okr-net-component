using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageCore.Domain.Abstraction
{
    public interface IRepository<T>
    {
        T FindById(object id);
        int Add(T obj);
    }
}
