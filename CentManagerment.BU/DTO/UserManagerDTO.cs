using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentManagerment.BU.DTO
{
    public class UserManagerDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public int? UserType { get; set; }
        public string FullName { get; set; }
        public string UserPhoneNumber { get; set; }
    }
}
