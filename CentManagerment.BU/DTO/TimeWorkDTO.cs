using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentManagerment.BU.DTO
{
    public class TimeWorkDTO
    {
        public int Id { get; set; }
        public Nullable<double> Hours { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> TeacherId { get; set; }
        public virtual TeacherDTO TeacherDTO { get; set; }
    }
}
