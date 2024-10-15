using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CustomerMP.Entities.Entities
{
    public class Ticket : BaseEntity
    {
        [Required]
        public int TicketNo { get; set; }
        [Required]
        public string Detail { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Time { get; set; }

        [ForeignKey("Customer")]
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}
