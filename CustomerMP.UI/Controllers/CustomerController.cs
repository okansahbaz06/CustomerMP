using CustomerMP.DataLayer;
using CustomerMP.Entities.Entities;
using CustomerMP.Service;
using CustomerMP.UI.Helper;
using CustomerMP.UI.Views.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CustomerMP.UI.Controllers
{

    [Authorize(Roles = "SuperAdmin, Admin")]
    public class CustomerController : Controller
    {
        CustomerService customerService = new CustomerService(new CustomerRepository());

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            var values = customerService.GetList();

            var customers = new List<CustomerModel>();
            foreach (var value in values)
            {
            var customer = new CustomerModel();


                customer.Id = value.Id;
                customer.Email = value.Email;
                customer.Name = value.Name;
                customer.Surname = value.Surname;
                customer.MobilePhoneNo = value.MobilePhoneNo;
                customer.HomeAdress = value.HomeAdress;
                customer.Tc= value.Tc;
                customer.WorkPhoneNo= value.WorkPhoneNo;
                customer.WorkAdress= value.WorkAdress;
                customer.Siradisimi = ExtraordinaryHelper.IsExtraordinary(value.Name) ? "Evet" : "Hayır";


                customers.Add(customer);
            }

            return View(customers);
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public IActionResult AddCustomer(Customer customers)
        {
            customerService.CustomerAdd(customers);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View();
        }
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = customerService.GetById(id);
            customerService.CustomerDelete(customer);
            return RedirectToAction("Index");

        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        public IActionResult UpdateCustomer(int id)
        {
            var customer = customerService.GetById(id);
            return View(customer);
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public IActionResult UpdateCustomer(Customer customers)
        {
            customerService.CustomerUpdate(customers);
            return RedirectToAction("Index");

        }

    }
}
