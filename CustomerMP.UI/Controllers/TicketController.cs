using CustomerMP.DataLayer.Repositories;
using CustomerMP.Entities.Entities;
using CustomerMP.Service.Contracts;
using CustomerMP.Service.Services;
using CustomerMP.UI.Helper;
using CustomerMP.UI.Views.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using NPoco;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerMP.UI.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class TicketController : Controller
    {
        private readonly TicketService _ticketService;
        private readonly CustomerService _customerService;
        //private readonly IMemoryCache _cache;
        private readonly TicketHelper _ticketHelper;

        public TicketController(TicketHelper ticketHelper)
        {
            _ticketService = new TicketService(new TicketRepository());
            _customerService = new CustomerService(new CustomerRepository());
            _ticketHelper = ticketHelper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _ticketService.GetAllTicketByCustomerAsync();
            var tickets = _ticketHelper.MapTickets(values);

            return View(tickets);
        }
        #region cache
        //[AllowAnonymous]
        //[HttpGet]
        //public async Task<IActionResult> Index()
        //{
        //    string cacheKey = "ticketList";
        //    if (!_cache.TryGetValue(cacheKey, out List<TicketModel> tickets))
        //    {
        //        var values = await _ticketService.GetAllTicketByCustomerAsync();

        //        // Helper sınıfını kullanarak biletleri mapleyelim
        //        tickets = _ticketHelper.MapTickets(values);

        //        var cacheOptions = new MemoryCacheEntryOptions()
        //            .SetSlidingExpiration(TimeSpan.FromMinutes(10));

        //        _cache.Set(cacheKey, tickets, cacheOptions);
        //    }

        //    return View(tickets);
        //}
        #endregion

        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        public async Task<IActionResult> AddTicket()
        {
            var customers = await _customerService.GetAllAsync();
            ViewBag.Customers = new SelectList(customers, "Id", "Name");
            return View();
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> AddTicket(TicketModel ticketModel)
        {
            var ticket = new Ticket
            {
                TicketNo = ticketModel.TicketNo,
                Detail = ticketModel.Detail,
                Location = ticketModel.Location,
                Time = ticketModel.Time,
                CustomerId = ticketModel.CustomerId
            };

            await _ticketService.TicketAddAsync(ticket);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var ticket = await _ticketService.GetByIdAsync(id);
            _ticketService.TicketDelete(ticket);
            return RedirectToAction("Index");

        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        public async Task<IActionResult> UpdateTicket(int id)
        {
            var ticket = await _ticketService.GetByIdAsync(id);
            var customers = await _customerService.GetAllAsync();
            ViewBag.Customers = customers;
            return View(ticket);
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public IActionResult UpdateTicket(Ticket ticket)
        {
            if (ticket.CustomerId == 0)
            {
                ticket.CustomerId = null;
            }
            _ticketService.TicketUpdate(ticket);
            return RedirectToAction("Index");
        }
    }
}
