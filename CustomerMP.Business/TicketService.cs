using CustomerMP.DataLayer.Contracts;
using CustomerMP.Entities.Entities;
using CustomerMP.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerMP.Service
{
    public class TicketService : ITicketService
        
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public Ticket GetById(int id)
        {
            return _ticketRepository.GetById(id);
        }

        public List<Ticket> GetList()
        {
            return _ticketRepository.GetAll();
        }
        public List<Ticket> GetAllTicketByCustomer()
        {
            return _ticketRepository.GetList();
        }

        public void TicketAdd(Ticket ticket)
        {
            _ticketRepository.Insert(ticket);
        }

        public void TicketDelete(Ticket ticket)
        {
            _ticketRepository.Delete(ticket);
        }

        public void TicketUpdate(Ticket ticket)
        {
            _ticketRepository.Update(ticket);
        }
    }
}
