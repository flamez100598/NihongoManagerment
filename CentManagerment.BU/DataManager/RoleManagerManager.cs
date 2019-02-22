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
    public class RoleManagerManager
    {
        CentManagermentEntities db = null;
        public RoleManagerManager()
        {
            db = new CentManagermentEntities();
        }
        public bool RoleManagerManagerInsert(RoleManagerDTO RoleManager)
        {
            try
            {
                return new RoleManagerDAO().Insert(new ConvertDataRoleManager().ConvertDataRoleManagerToEF(RoleManager));
            }
            catch (Exception)
            {
                
                return false;
            }
        }
        public bool RoleManagerManagerUpdate(RoleManagerDTO RoleManager)
        {
            try
            {
                return new RoleManagerDAO().Update(new ConvertDataRoleManager().ConvertDataRoleManagerToEF(RoleManager));
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool RoleManagerManagerDelete(RoleManagerDTO RoleManager)
        {
            try
            {
                return new RoleManagerDAO().Delete(new ConvertDataRoleManager().ConvertDataRoleManagerToEF(RoleManager));
            }
            catch (Exception)
            {

                return false;
            }
        }
        public List<RoleManagerDTO> GetListRoleManagerByUserID(UserManagerDTO user)
        {
            var list = db.RoleManagers.ToList();
            var listDTO = new List<RoleManagerDTO>();
            foreach (var item in list)
            {
                if (item.RoleManagerUserId == user.UserId)
                    listDTO.Add(new ConvertDataRoleManager().ConvertDataRoleManagerToDTO(item));
            }
            return listDTO;
        }
        public List<int> GetListRoleIdByUserName(string userName)
        {
            var list = from a in db.RoleManagers
                       join b in db.Roles on a.RoleManagerRoleId equals b.RoleId
                       join c in db.UserManagers on a.RoleManagerUserId equals c.UserId
                       where c.UserName == userName
                       select new RoleManagerDTO
                       {
                           RoleManagerRoleId = a.RoleManagerRoleId,
                           RoleManagerUserId = a.RoleManagerUserId
                       };
            return list.Select(x => x.RoleManagerRoleId.Value).ToList();
        }

    }
}
