using CustomerMP.Entities.Entities;
using System;

namespace CustomerMP.UI.Views.Models
{
    public class TicketModel
    {
        public int Id { get; set; }
        public int TicketNo { get; set; }
        public string Detail { get; set; }
        public string Location { get; set; }
        public string Time { get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
