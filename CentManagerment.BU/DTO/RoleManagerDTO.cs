using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentManagerment.BU.DTO
{
    [Serializable]
    public class RoleManagerDTO
    {
        public int RoleManagerId { get; set; }
        public int? RoleManagerUserId { get; set; }
        public int? RoleManagerRoleId { get; set; }
    }
}
