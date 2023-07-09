using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageCore.Domain.Abstraction
{
    public interface IRepository<T>
    {
        Task<bool> Create(T obj);
        Task<List<T>> GetAll();
        Task<T> Update(T obj);
        Task<bool> Delete(int key);
        Task<T> GetById(int id);
    }
}
