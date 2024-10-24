using CustomerMP.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerMP.Service.Contracts
{
    public interface ITicketService
    {
        Task<Ticket> TicketAddAsync(Ticket ticket);
        void TicketDelete(Ticket ticket);
        void TicketUpdate(Ticket ticket);
        Task<IEnumerable<Ticket>> GetAllAsync();
        Task<IEnumerable<Ticket>> GetAllTicketByCustomerAsync();
        Task<Ticket> GetByIdAsync(int id);
    }
}
