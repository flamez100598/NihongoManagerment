using CentManagerment.BU.DTO;
using CentManagerment.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentManagerment.BU.ConvertData
{
    public class ConvertDataRoleManager
    {
        public RoleManagerDTO ConvertDataRoleManagerToDTO(RoleManager roleManager)
        {
            var roleManagerDTO = new RoleManagerDTO()
            {
                RoleManagerId = roleManager.RoleManagerId,
                RoleManagerRoleId = roleManager.RoleManagerRoleId,
                RoleManagerUserId = roleManager.RoleManagerUserId
            };
            return roleManagerDTO;
        }
        public RoleManager ConvertDataRoleManagerToEF(RoleManagerDTO roleManager)
        {
            var roleManagerEF = new RoleManager()
            {
                RoleManagerRoleId = roleManager.RoleManagerRoleId,
                RoleManagerUserId = roleManager.RoleManagerUserId
            };
            if (roleManager.RoleManagerId > 0)
            {

                roleManagerEF.RoleManagerId = roleManager.RoleManagerId;
            }
            return roleManagerEF;
        }
    }
}
