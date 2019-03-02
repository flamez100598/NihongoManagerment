using CentManagerment.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentManagerment.Model.DAO
{
    public class RevenueMonthDAO
    {
        public bool Update(int Period, int IdRM)
        {
            try
            {
                using (var db = new CentManagermentEntities())
                {
                    var find = db.RevenueMonths.Find(IdRM);
                    find.Period = Period;
                    db.SaveChanges();
                return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Insert(RevenueMonth ef)
        {
            try
            {
                using (var db = new CentManagermentEntities())
                {
                    db.RevenueMonths.Add(ef);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
