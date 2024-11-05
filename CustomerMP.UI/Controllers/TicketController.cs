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
using System.Linq;
using System.Threading.Tasks;

namespace CustomerMP.UI.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly ICustomerService _customerService;
        private readonly TicketHelper _ticketHelper;
        private readonly CacheHelper _cacheHelper;

        public TicketController(TicketHelper ticketHelper, CacheHelper cacheHelper, ITicketService ticketService, ICustomerService customerService)
        {

            _ticketHelper = ticketHelper;
            _cacheHelper = cacheHelper;
            _ticketService = ticketService;
            _customerService = customerService;
        }
        #region cache
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string cacheKey = "ticketList";
            var tickets = await _cacheHelper.GetOrCreateAsync(
                cacheKey,
                async () => _ticketHelper.MapTickets((await _ticketService.GetAllTicketByCustomerAsync()).ToList())
            );

            return View(tickets);
        }
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
            _cacheHelper.Remove("ticketList");
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var ticket = await _ticketService.GetByIdAsync(id);
            _ticketService.TicketDelete(ticket);
            _cacheHelper.Remove("ticketList");
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
            _cacheHelper.Remove("ticketList");
            return RedirectToAction("Index");
        }
    }
}
