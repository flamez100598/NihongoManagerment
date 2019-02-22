using CentManagerment.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentManagerment.Model.DAO
{
    public class ExpenditureDAO
    {
        CentManagermentEntities db = null;

        // use using to open and close connection

        public bool Insert(Expenditure expenditure)
        {
            using (db = new CentManagermentEntities())
            {
                db.Expenditures.Add(expenditure);
                db.SaveChanges();
                return true;
            }

        }
        // use using to open and close connection

        public bool Update(Expenditure expenditure)
        {
            using (db = new CentManagermentEntities())
            {
                var expenditureUpdate = db.Expenditures.FirstOrDefault(x => x.ExpenditureId == expenditure.ExpenditureId);
                expenditureUpdate.ExpenditureName = expenditure.ExpenditureName;
                expenditureUpdate.Price = expenditure.Price;
                db.SaveChanges();
                return true;
            }

        }
        // use using to open and close connection

        public bool Delete(Expenditure expenditure)
        {
            using (db = new CentManagermentEntities())
            {
                db.Expenditures.Remove(expenditure);
                db.SaveChanges();
                return true;
            }

        }
    }
}
