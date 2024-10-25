using CustomerMP.DataLayer;
using CustomerMP.DataLayer.Repositories;
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
        private readonly CustomerService _customerService;
        private readonly IMemoryCache _cache;
        private readonly CustomerHelper _customerHelper;

        public CustomerController(CustomerHelper customerHelper, IMemoryCache cache)
        {
            _customerHelper = customerHelper;
            _customerService = new CustomerService(new CustomerRepository());
            _cache = cache;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string cacheKey = "customerList";
            if (!_cache.TryGetValue(cacheKey, out List<CustomerModel> customers))
            {
                var values = (await _customerService.GetAllAsync()).ToList();

                // Helper sınıfını kullanarak biletleri mapleyelim
                customers = _customerHelper.MapCustomers(values);

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(10));

                _cache.Set(cacheKey, customers, cacheOptions);
            }

            return View(customers);
        }


        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> AddCustomer(Customer customers)
        {
            await _customerService.CustomerAddAsync(customers);
            _cache.Remove("customerList");
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
            _cache.Remove("customerList");
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
            _cache.Remove("customerList");
            return RedirectToAction("Index");

        }

    }
}
