using System.Collections.Generic;

namespace CustomerMP.DataLayer.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        void Insert(T t);
        void Delete(T t);
        void Update(T t);
        List<T> GetAll();
        T GetById(int id);

    }
}