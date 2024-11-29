using CustomerMP.Entities.Entities;
using CustomerMP.UI.Views.Models;
using System.Collections.Generic;

namespace CustomerMP.UI.Helper
{
    public class CustomerHelper
    {
        public List<CustomerModel> MapCustomers(IEnumerable<Customer> values)
        {
            var customers = new List<CustomerModel>();

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

            return customers;
        }
    }
}
