using CentManagerment.BU.DTO;
using CentManagerment.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentManagerment.BU.ConvertData
{
    public class ConvertDataRole
    {
        public RoleDTO ConvertDataRoleToDTO(Role role)
        {
            var roleDTO = new RoleDTO()
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName,
            };
            return roleDTO;
        }
        public Role ConvertDataRoleToEF(RoleDTO role)
        {
            var roleEF = new Role()
            {
                RoleName = role.RoleName,
            };
            if(role.RoleId > 0)
            {
                roleEF.RoleId = role.RoleId;
            }
            return roleEF;
        }
    }
}
