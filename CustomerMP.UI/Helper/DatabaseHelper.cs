using CustomerMP.DataLayer.DBContext;
using CustomerMP.Entities.Entities;
using CustomerMP.UI.Enums;
using System;

namespace CustomerMP.UI.Helper
{
    public class DatabaseHelper
    {
        private readonly CustomerMP_DBContext _context;

        public DatabaseHelper(CustomerMP_DBContext context)
        {
            _context = context;
        }

        public bool AddUserLog(UserLogType user_log_type, string desc, string username)
        {
            var ulog = new UserLog
            {
                Date = DateTime.UtcNow.AddHours(3),
                Description = desc,
                Username = username,
                UserLogType = user_log_type.ToString()
            };

            _context.UserLogs.Add(ulog);
            _context.SaveChanges();
            return true;
        }
    }
}
