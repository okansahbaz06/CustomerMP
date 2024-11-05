using CustomerMP.DataLayer;
using CustomerMP.DataLayer.Repositories;
using CustomerMP.DataLayer.UnitOfWork;
using CustomerMP.Entities.Entities;
using CustomerMP.Service.Contracts;
using CustomerMP.Service.Services;
using CustomerMP.UI.Helper;
using CustomerMP.UI.Views.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CustomerMP.UI.Controllers
{

    [Authorize(Roles = "SuperAdmin, Admin")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly CacheHelper _cacheHelper;
        private readonly CustomerHelper _customerHelper;


        public CustomerController(CustomerHelper customerHelper, CacheHelper cacheHelper, ICustomerService customerService)
        {
            _customerHelper = customerHelper;

            _cacheHelper = cacheHelper;
            _customerService = customerService;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string cacheKey = "customerList";
            var customers = await _cacheHelper.GetOrCreateAsync(
                cacheKey,
                async () => _customerHelper.MapCustomers((await _customerService.GetAllAsync()).ToList())
            );

            return View(customers);
        }


        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> AddCustomer(Customer customers)
        {
            await _customerService.CustomerAddAsync(customers);
            _cacheHelper.Remove("customerList");
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View();
        }
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer =  await _customerService.GetByIdAsync(id);
            _customerService.CustomerDelete(customer);
            _cacheHelper.Remove("customerList");
            return RedirectToAction("Index");

        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        public async Task<IActionResult> UpdateCustomer(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            return View(customer);
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public IActionResult UpdateCustomer(Customer customers)
        {
            _customerService.CustomerUpdate(customers);
            _cacheHelper.Remove("customerList");
            return RedirectToAction("Index");

        }

    }
}
