using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CustomerMP.Entities.Entities
{
    public class BaseEntity
    {
        [Key]
        [JsonProperty("id")]
        public int Id { get; set; }

    }
}
