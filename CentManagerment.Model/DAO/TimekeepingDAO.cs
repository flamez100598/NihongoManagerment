using CentManagerment.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentManagerment.Model.DAO
{
    public class TimekeepingDAO
    {
        CentManagermentEntities db = null;
        public bool Insert(Timekeeping cl)
        {
            try
            {
                using (db = new CentManagermentEntities())
                {
                    db.Timekeepings.Add(cl);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }
        // use using to open and close connection
        public bool Update(Timekeeping cl)
        {
            using (db = new CentManagermentEntities())
            {
                var clUpdate = db.Timekeepings.FirstOrDefault(x => x.ID == cl.ID);
                //clUpdate.Hours = cl.Hours;
                //clUpdate.Date = cl.Date;
                db.SaveChanges();
            }
            return true;


        }
        // use using to open and close connection
        public bool Delete(int cl)
        {
            using (db = new CentManagermentEntities())
            {
                var delete = db.Timekeepings.Find(cl);
                db.Timekeepings.Remove(delete);
                db.SaveChanges();
            }
            return true;
        }
    }
}
