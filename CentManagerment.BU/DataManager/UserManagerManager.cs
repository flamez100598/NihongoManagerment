using CentManagerment.BU.Common;
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
    public class UserManagerManager
    {
        CentManagermentEntities db = null;
        public UserManagerManager()
        {
            db = new CentManagermentEntities();
        }
        public bool UserManagerManagerInsert(UserManagerDTO UserManager)
        {
            try
            {
                new UserManagerDAO().Insert(new ConvertDataUserManager().ConvertDataUserManagerToEF(UserManager));
                var listRole = db.Roles.ToList();
                var userId = db.UserManagers.OrderByDescending(p => p.UserId).FirstOrDefault().UserId;
                if (UserManager.UserType == 1)
                {
                    foreach (var item in listRole)
                    {
                        new RoleManagerManager().RoleManagerManagerInsert(new RoleManagerDTO { RoleManagerUserId = userId, RoleManagerRoleId = item.RoleId });
                    }
                }
                else
                {
                    new RoleManagerManager().RoleManagerManagerInsert(new RoleManagerDTO { RoleManagerUserId = UserManager.UserId, RoleManagerRoleId = 1 });
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UserManagerManagerUpdate(UserManagerDTO UserManager)
        {
            try
            {
                new UserManagerDAO().Update(new ConvertDataUserManager().ConvertDataUserManagerToEF(UserManager));
                var listRole = db.Roles.ToList();
                if (UserManager.UserType == 1)
                {
                    var listRoleManagerByUserId = new RoleManagerManager().GetListRoleManagerByUserID(UserManager);
                    foreach (var item in listRoleManagerByUserId)
                    {
                        new RoleManagerManager().RoleManagerManagerDelete(item);
                    }
                    foreach (var item in listRole)
                    {
                        new RoleManagerManager().RoleManagerManagerInsert(new RoleManagerDTO { RoleManagerUserId = UserManager.UserId, RoleManagerRoleId = item.RoleId });
                    }
                }
                else
                {
                    var listRoleManagerByUserId = new RoleManagerManager().GetListRoleManagerByUserID(UserManager);
                    foreach (var item in listRoleManagerByUserId)
                    {
                        new RoleManagerManager().RoleManagerManagerDelete(item);
                    }
                    new RoleManagerManager().RoleManagerManagerInsert(
                        new RoleManagerDTO { RoleManagerUserId = UserManager.UserId, RoleManagerRoleId = 1 });
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool UserManagerManagerDelete(UserManagerDTO UserManager)
        {
            try
            {
                new UserManagerManager().UserManagerManagerDelete(UserManager);
                var listRoleManagerByUserId = new RoleManagerManager().GetListRoleManagerByUserID(UserManager);
                foreach (var item in listRoleManagerByUserId)
                {
                    new RoleManagerManager().RoleManagerManagerDelete(item);
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public List<UserManagerDTO> GetListUserManagers()
        {
            try
            {
                var list = db.UserManagers.ToList();
                var listDTO = new List<UserManagerDTO>();
                foreach (var item in list)
                {
                    listDTO.Add(new ConvertDataUserManager().ConvertDataUserManagerToDTO(item));
                }
                return listDTO;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<UserManagerDTO> GetListUserManagersMinusUserLogin(UserManagerDTO UserLogin)
        {
            try
            {
                var list = db.UserManagers.OrderBy(x=>x.UserType).ToList();
                var listDTO = new List<UserManagerDTO>();
                foreach (var item in list)
                {
                    if (item.UserId != new ConvertDataUserManager().ConvertDataUserManagerToEF(UserLogin).UserId)
                        listDTO.Add(new ConvertDataUserManager().ConvertDataUserManagerToDTO(item));
                }
                return listDTO;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public UserManagerDTO LoginUserByLoginModel(LoginModelDTO loginModel)
        {
            try
            {
                db = new CentManagermentEntities();
                var user = new UserManager();
                var getList = db.UserManagers.ToList();
                user = db.UserManagers.FirstOrDefault(x => x.UserName == loginModel.UserName && x.UserPassword == loginModel.UserPassword);
                if (user != null)
                {
                    var userFind = new ConvertDataUserManager().ConvertDataUserManagerToDTO(user);
                    return userFind;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public UserManagerDTO FindUserById(int idUser)
        {
            try
            {
                var user = new UserManager();
                user = db.UserManagers.Find(idUser);
                if (user != null)
                {
                    var userFind = new ConvertDataUserManager().ConvertDataUserManagerToDTO(user);
                    return userFind;
                }
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public bool AddUserManagerHandleByUserName(string UserName, List<int> listType)
        {
            try
            {
                if (UserName != "" && listType != null)
                {
                    UserManagerDTO userDTO = new UserManagerDTO();
                    userDTO = new ConvertDataUserManager().ConvertDataUserManagerToDTO(db.UserManagers.FirstOrDefault(x => x.UserName == UserName));
                    var listRoleManagerByUserId = new RoleManagerManager().GetListRoleManagerByUserID(userDTO);
                    foreach (var item in listRoleManagerByUserId)
                    {
                        new RoleManagerManager().RoleManagerManagerDelete(item);
                    }
                    foreach (var item in listType)
                    {
                        new RoleManagerManager().RoleManagerManagerInsert(new RoleManagerDTO { RoleManagerUserId = userDTO.UserId, RoleManagerRoleId = item });
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
