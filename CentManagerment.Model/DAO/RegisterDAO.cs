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
                catch (Exception ex)
                {
                    return false;
                }
            }

        }
    }
}
