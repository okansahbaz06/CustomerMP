using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerMP.Entities.Entities
{
    public class UserLog : BaseEntity
    {
        public string Username { get; set; }
        public string Description { get; set; }
        public string UserLogType { get; set; }
        public DateTime Date { get; set; }
    }
}
