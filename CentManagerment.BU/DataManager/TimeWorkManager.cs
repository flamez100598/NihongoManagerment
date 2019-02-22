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
    public class TimeWorkManager
    {
        CentManagermentEntities db = null;
        TimeWorkDAO dao = new TimeWorkDAO();
        ConvertDataTimeWork convert = new ConvertDataTimeWork();
        //insert Time Work
        public bool Insert(TimeWorkDTO dto)
        {
            var teacher = convert.ConvertDataTimeWorkToEF(dto);
            return dao.Insert(teacher);
        }
    }
}
