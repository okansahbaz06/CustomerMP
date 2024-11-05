using CustomerMP.DataLayer.Contracts;
using CustomerMP.DataLayer.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerMP.DataLayer.UnitOfWork;

namespace CustomerMP.DataLayer.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly CustomerMP_DBContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public GenericRepository(IUnitOfWork unitOfWork, CustomerMP_DBContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public void Delete(T t)
        {
            _context.Remove(t);
            _unitOfWork.Commit();
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking().AsQueryable();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);

        }

        public async Task AddAsync(T t)
        {
            await _context.Set<T>().AddAsync(t);
            await _unitOfWork.CommitAsync();
        }

        public void Update(T t)
        {
            _context.Update(t);
            _unitOfWork.Commit();
        }
    }
}