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
    public class RevenueManager
    {
        CentManagermentEntities db = null;
        public RevenueManager()
        {
            db = new CentManagermentEntities();
        }

        public List<RevenueDTO> ListRevenue()
        {
            List<Student> listStudent = db.Students.ToList();
            return new ConvertDataRevenue().ConvertDataRevenueToDTO(listStudent);
        }

    }
}
