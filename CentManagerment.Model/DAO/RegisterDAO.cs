using CentManagerment.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentManagerment.Model.DAO
{
    public class RegisterDAO
    {
        CentManagermentEntities db = null;
        public bool Insert(RegisterManagerment register)
        {
            using (db = new CentManagermentEntities())
            {
                try
                {
                    db.RegisterManagerments.Add(register);
                    db.SaveChanges();
                    return true;

                }
                catch (Exception)
                {
                    return false;
                }
            }

        }
        public bool Update(int id, int status)
        {
            using (db = new CentManagermentEntities())
            {
                try
                {
                    var get = db.RegisterManagerments.Find(id);

                    get.register_status = status;
                    
                    db.SaveChanges();
                    return true;

                }
                catch (Exception)
                {
                    return false;
                }
            }

        }

        public bool Delete(int id)
        {
            using (db = new CentManagermentEntities())
            {
                try
                {
                    var get = db.RegisterManagerments.Find(id);
                    db.RegisterManagerments.Remove(get);
                    db.SaveChanges();
                    return true;

                }
                catch (Exception)
                {
                    return false;
                }
            }

        }

    }
}
