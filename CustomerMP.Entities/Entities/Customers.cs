using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerMP.Entities.Entities
{
    public class Customers
    {
        [Key]
        [JsonProperty("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(11)]
        [JsonProperty("tc")]
        public string Tc { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("surname")]
        public string Surname { get; set; }

        [Required]
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("homephoneno")]
        public string HomePhoneNo { get; set; }

        [JsonProperty("workphoneno")]
        public string WorkPhoneNo { get; set; }

        [JsonProperty("mobilephoneno")]
        public string MobilePhoneNo { get; set; }

        [JsonProperty("homeadress")]
        public string HomeAdress { get; set; }

        [JsonProperty("workadress")]
        public string WorkAdress { get; set; }

    }
}
