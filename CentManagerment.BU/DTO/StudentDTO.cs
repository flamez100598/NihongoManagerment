using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentManagerment.BU.DTO
{
    public class StudentDTO
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int? StudentMark { get; set; }
        public int? StudentClassID { get; set; }
        public double? StudentSchoolFee { get; set; }
        public string StudentEmail { get; set; }
        public string StudentPhone { get; set; }
        public string StudentAdress { get; set; }
        public bool? StudentSchoolFeeStatus { get; set; }
        public DateTime? StudentSchoolFeeDate { get; set; }

        public virtual ClassDTO ClassDTO { get; set; }
    }
}
