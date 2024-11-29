using CustomerMP.Entities.Entities;
using CustomerMP.UI.Views.Models;
using System.Collections.Generic;

namespace CustomerMP.UI.Helper
{
    public class TicketHelper
    {
        public List<TicketModel> MapTickets(IEnumerable<Ticket> values)
        {
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
                    Customer = value.Customer ?? new Customer // Eğer customer null ise, yeni bir boş müşteri oluşturuluyor
                    {
                        Name = "",
                        Surname = ""
                    }
                };

                tickets.Add(ticket);
            }

            return tickets;
        }
    }

}

