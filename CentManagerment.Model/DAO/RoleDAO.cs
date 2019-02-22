using CentManagerment.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentManagerment.Model.DAO
{
    public class RoleDAO
    {
        CentManagermentEntities db = null;
        // use using to open and close connection
        public bool Insert(Role role)
        {
            using (db = new CentManagermentEntities())
            {
                db.Roles.Add(role);
                db.SaveChanges();
            }
            return true;


        }
        // use using to open and close connection
        public bool Update(Role role)
        {
            using (db = new CentManagermentEntities())
            {
                var roleUpdate = db.Roles.FirstOrDefault(x => x.RoleId == role.RoleId);
                roleUpdate.RoleName = role.RoleName;
                db.SaveChanges();
            }
            return true;


        }
        // use using to open and close connection
        public bool Delete(Role role)
        {
            using (db = new CentManagermentEntities())
            {
                db.Roles.Remove(role);
                db.SaveChanges();
            }
            return true;


        }
    }
}
