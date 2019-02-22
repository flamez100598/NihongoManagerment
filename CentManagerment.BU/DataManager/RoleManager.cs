using CentManagerment.BU.ConvertData;
using CentManagerment.BU.DTO;
using CentManagerment.Model.DAO;
using CentManagerment.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentManagerment.BU.DataManager
{
    public class RoleManager
    {
        CentManagermentEntities db = null;
        public RoleManager()
        {
            db = new CentManagermentEntities();
        }
        public bool RoleManagerInsert(RoleDTO Role)
        {
            try
            {
                return new RoleDAO().Insert(new ConvertDataRole().ConvertDataRoleToEF(Role));
            }
            catch (Exception)
            {
                
                return false;
            }
        }
        public bool RoleManagerUpdate(RoleDTO Role)
        {
            try
            {
                return new RoleDAO().Update(new ConvertDataRole().ConvertDataRoleToEF(Role));
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool RoleManagerDelete(RoleDTO Role)
        {
            try
            {
                return new RoleDAO().Delete(new ConvertDataRole().ConvertDataRoleToEF(Role));
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
