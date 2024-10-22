using CustomerMP.DataLayer;
using CustomerMP.DataLayer.Repositories;
using CustomerMP.Entities.Entities;
using CustomerMP.Service.Services;
using CustomerMP.UI.Helper;
using CustomerMP.UI.Views.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CustomerMP.UI.Controllers
{

    [Authorize(Roles = "SuperAdmin, Admin")]
    public class CustomerController : Controller
    {
        CustomerService customerService = new CustomerService(new CustomerRepository());
        private readonly IMemoryCache _cache;

        public CustomerController(IMemoryCache cache)
        {
            _cache = cache;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string cacheKey = "customerList";

            if (!_cache.TryGetValue(cacheKey, out List<CustomerModel> customers))
            {
                var values = await customerService.GetAllAsync();

                customers = new List<CustomerModel>();
                foreach (var value in values)
                {
                    var customer = new CustomerModel
                    {
                        Id = value.Id,
                        Email = value.Email,
                        Name = value.Name,
                        Surname = value.Surname,
                        MobilePhoneNo = value.MobilePhoneNo,
                        HomeAdress = value.HomeAdress,
                        Tc = value.Tc,
                        WorkPhoneNo = value.WorkPhoneNo,
                        WorkAdress = value.WorkAdress,
                        Siradisimi = ExtraordinaryHelper.IsExtraordinary(value.Name) ? "Evet" : "Hayır"
                    };

                    customers.Add(customer);
                }

                // Cache'e ekleyelim (10 dakika boyunca saklasın)
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
            await customerService.CustomerAddAsync(customers);
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
            var customer =  await customerService.GetByIdAsync(id);
            customerService.CustomerDelete(customer);
            return RedirectToAction("Index");

        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        public async Task<IActionResult> UpdateCustomer(int id)
        {
            var customer = await customerService.GetByIdAsync(id);
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
