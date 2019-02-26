using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentManagerment.BU.DTO
{
    public class TimekeepingDTO
    {
        public int ID { get; set; }
        public DateTime? TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
        public int? TeacherID { get; set; }

        public virtual TeacherDTO TeacherDTO { get; set; }


        //
        public double Hours { get; set; }
        public string Days { get; set; }
        public string TimeInStr { get; set; }
        public string TimeOutStr { get; set; }
        public string TimeHours { get; set; }
    }
}
