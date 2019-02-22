using CentManagerment.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentManagerment.Model.DAO
{
    public class RevenueDAO
    {
        CentManagermentEntities db = null;
        // use using to open and close connection
        public bool Insert(Revenue revenue)
        {
            using (db = new CentManagermentEntities())
            {
                db.Revenues.Add(revenue);
                db.SaveChanges();
                return true;
            }

        }
        // use using to open and close connection
        public bool Update(Revenue revenue)
        {
            using (db = new CentManagermentEntities())
            {
                var revenueUpdate = db.Revenues.FirstOrDefault(x => x.RevenueId == revenue.RevenueId);
                revenueUpdate.RevenuePrice = revenue.RevenuePrice;
                revenueUpdate.RevenueStartPaymentDay = revenue.RevenueStartPaymentDay;
                revenueUpdate.RevenueStudentId = revenue.RevenueStudentId;
                db.SaveChanges();
            }
            return true;


        }
        // use using to open and close connection
        public bool Delete(Revenue revenue)
        {
            using (db = new CentManagermentEntities())
            {
                db.Revenues.Remove(revenue);
                db.SaveChanges();
            }
            return true;


        }
    }
}
