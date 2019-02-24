using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentManagerment.BU.DTO
{
    public class TeacherDTO
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public int? Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public double? TimeToWork { get; set; }
        public int? PricePerHour { get; set; }
        public double? Total { get; set; }
        public string LevelEducation { get; set; }
        public int? Status { get; set; }
        public string StatusName { get; set; }
    }
}
