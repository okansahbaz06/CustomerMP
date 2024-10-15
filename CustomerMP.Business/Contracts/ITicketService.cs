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
        void TicketAdd(Ticket ticket);
        void TicketDelete(Ticket ticket);
        void TicketUpdate(Ticket ticket);
        List<Ticket> GetList();
        Ticket GetById(int id);
    }
}
