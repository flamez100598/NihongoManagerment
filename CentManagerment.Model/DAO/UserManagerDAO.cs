using CentManagerment.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentManagerment.Model.DAO
{
    public class UserManagerDAO
    {

        CentManagermentEntities db = null;
        // use using to open and close connection

        public bool Insert(UserManager userManager)
        {
            using (db = new CentManagermentEntities())
            {
                db.UserManagers.Add(userManager);
                db.SaveChanges();
            }
            return true;


        }
        // use using to open and close connection

        public bool Update(UserManager userManager)
        {
            using (db = new CentManagermentEntities())
            {
                var userManagerUpdate = db.UserManagers.FirstOrDefault(x => x.UserId == userManager.UserId);
                userManagerUpdate.UserPassword = userManager.UserPassword;
                userManagerUpdate.UserPhoneNumber = userManager.UserPhoneNumber;
                userManagerUpdate.FullName = userManager.FullName;
                userManagerUpdate.UserType = userManager.UserType;
                db.SaveChanges();
            }
            return true;

        }
        // use using to open and close connection

        public bool Delete(UserManager userManager)
        {
            using (db = new CentManagermentEntities())
            {
                var userDelete = db.UserManagers.FirstOrDefault(x => x.UserId == userManager.UserId);
                db.UserManagers.Remove(userDelete);
                db.SaveChanges();
            }
            return true;


        }
    }
}
