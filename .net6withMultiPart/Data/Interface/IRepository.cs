using System.Collections.Generic;
using System.Threading.Tasks;
using arquivoApi.Models;

namespace arquivoApi.Data.Interface
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> Add(T item);
        T GetById(long id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Update(T item);
        void Delete(long id);
        bool Exists(long? id);
    }
}