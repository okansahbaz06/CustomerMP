using CustomerMP.DataLayer;
using CustomerMP.Entities.Entities;
using CustomerMP.Service;
using CustomerMP.Service.Contracts;
using CustomerMP.UI.Helper;
using CustomerMP.UI.Views.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Data;

namespace CustomerMP.UI.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class TicketController : Controller
    {
        TicketService ticketService = new TicketService(new TicketRepository());
        CustomerService customerService = new CustomerService(new CustomerRepository());

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            var values = ticketService.GetAllTicketByCustomer();
            var tickets = new List<TicketModel>();

            foreach (var value in values)
            {
                var ticket = new TicketModel
                {
                    Id = value.Id,
                    TicketNo = value.TicketNo,
                    Detail = value.Detail,
                    Location = value.Location,
                    Time = value.Time,
                    Customer = value.Customer 
                };

                
                if (ticket.Customer == null)
                {
                    ticket.Customer = new Customer
                    {
                        Name = "",
                        Surname = ""
                    };
                }

                tickets.Add(ticket);
            }

            return View(tickets);
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        public IActionResult AddTicket()
        {
            var customers = customerService.GetList();
            ViewBag.Customers = new SelectList(customers, "Id", "Name");
            return View();
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public IActionResult AddTicket(TicketModel ticketModel)
        {
            var ticket = new Ticket
            {
                TicketNo = ticketModel.TicketNo,
                Detail = ticketModel.Detail,
                Location = ticketModel.Location,
                Time = ticketModel.Time,
                CustomerId = ticketModel.CustomerId
            };

            ticketService.TicketAdd(ticket);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "SuperAdmin")]
        public IActionResult DeleteTicket(int id)
        {
            var ticket = ticketService.GetById(id);
            ticketService.TicketDelete(ticket);
            return RedirectToAction("Index");

        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        public IActionResult UpdateTicket(int id)
        {
            var ticket = ticketService.GetById(id);
            var customers = customerService.GetList();
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
            ticketService.TicketUpdate(ticket);
            return RedirectToAction("Index");
        }
    }
}
