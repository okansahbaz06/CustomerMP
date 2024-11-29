using CustomerMP.DataLayer.DBContext;
using CustomerMP.DataLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerMP.Service.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CustomerMP_DBContext _context;

        public UnitOfWork(CustomerMP_DBContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
