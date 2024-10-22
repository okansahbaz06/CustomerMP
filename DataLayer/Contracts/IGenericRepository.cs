using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerMP.DataLayer.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T t);
        void Delete(T t);
        void Update(T t);
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(int id);

    }
}