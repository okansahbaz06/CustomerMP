using CustomerMP.DataLayer.Contracts;
using CustomerMP.DataLayer.DBContext;
using System.Collections.Generic;
using System.Linq;

namespace CustomerMP.DataLayer
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        CustomerMP_DBContext context = new CustomerMP_DBContext();
        public void Delete(T t)
        {
            context.Remove(t);
            context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return context.Set<T>().Find(id);

        }

        public void Insert(T t)
        {
            context.Add(t);
            context.SaveChanges();
        }

        public void Update(T t)
        {
            context.Update(t);
            context.SaveChanges();
        }
    }
}