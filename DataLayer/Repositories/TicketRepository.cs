using CustomerMP.DataLayer.Contracts;
using CustomerMP.DataLayer.DBContext;
using CustomerMP.DataLayer.UnitOfWork;
using CustomerMP.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerMP.DataLayer.Repositories
{
    public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(IUnitOfWork unitOfWork, CustomerMP_DBContext customerMP_DBContext) : base(unitOfWork, customerMP_DBContext)
        {
        }

        public async Task<IEnumerable<Ticket>> GetListAsync()
        {
            return await _context.Tickets.Include(t => t.Customer).ToListAsync();
        }
    }
}
