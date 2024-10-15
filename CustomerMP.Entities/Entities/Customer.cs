using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerMP.Entities.Entities
{
    public class Customer : BaseEntity
    {
        [Required]
        [MaxLength(11)]
        public string Tc { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Email { get; set; }

        public string WorkPhoneNo { get; set; }

        public string MobilePhoneNo { get; set; }

        public string HomeAdress { get; set; }

        public string WorkAdress { get; set; }

        public ICollection<Ticket> Tickets { get; set; }

    }
}
