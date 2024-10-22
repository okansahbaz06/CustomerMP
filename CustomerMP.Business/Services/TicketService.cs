using CustomerMP.DataLayer.Contracts;
using CustomerMP.DataLayer.Repositories;
using CustomerMP.Entities.Entities;
using CustomerMP.Service.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerMP.Service.Services
{
    public class TicketService : ITicketService

    {
        private readonly ITicketRepository _ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<Ticket> GetByIdAsync(int id)
        {
            return await _ticketRepository.GetByIdAsync(id);

        }

        public async Task<IEnumerable<Ticket>> GetAllAsync()
        {
            return await _ticketRepository.GetAll().ToListAsync();

        }
        public async Task<IEnumerable<Ticket>> GetAllTicketByCustomer()
        {
            return await _ticketRepository.GetListAsync();
        }

        public async Task<Ticket> TicketAddAsync(Ticket ticket)
        {
            await _ticketRepository.AddAsync(ticket);
            return ticket;
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
