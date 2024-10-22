using CustomerMP.DataLayer.Contracts;
using CustomerMP.DataLayer.DBContext;
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
        CustomerMP_DBContext context = new CustomerMP_DBContext();
        public async Task<IEnumerable<Ticket>> GetListAsync()
        {
            return await context.Tickets.Include(t => t.Customer).ToListAsync();
        }
    }
}
