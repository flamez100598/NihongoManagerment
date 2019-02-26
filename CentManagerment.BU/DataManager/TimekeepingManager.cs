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
    public class TimekeepingManager
    {
        CentManagermentEntities db = null;
        TimekeepingDAO dao = new TimekeepingDAO();
        ConvertDataTimekeeping convert = new ConvertDataTimekeeping();
        //insert Time Work
        public bool Insert(TimekeepingDTO dto)
        {
            var teacher = convert.ConvertDataTimekeepingToEF(dto);
            return dao.Insert(teacher);
        }
    }
}
