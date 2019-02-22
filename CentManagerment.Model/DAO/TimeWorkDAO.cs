using CentManagerment.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentManagerment.Model.DAO
{
    public class TimeWorkDAO
    {
        CentManagermentEntities db = null;
        public bool Insert(TimeWork cl)
        {
            using (db = new CentManagermentEntities())
            {
                db.TimeWorks.Add(cl);
                db.SaveChanges();
            }
            return true;

        }
        // use using to open and close connection
        public bool Update(TimeWork cl)
        {
            using (db = new CentManagermentEntities())
            {
                var clUpdate = db.TimeWorks.FirstOrDefault(x => x.Id == cl.Id);
                clUpdate.Hours = cl.Hours;
                clUpdate.Date = cl.Date;
                db.SaveChanges();
            }
            return true;


        }
        // use using to open and close connection
        public bool Delete(int cl)
        {
            using (db = new CentManagermentEntities())
            {
                var delete = db.TimeWorks.Find(cl);
                db.TimeWorks.Remove(delete);
                db.SaveChanges();
            }
            return true;
        }
    }
}
