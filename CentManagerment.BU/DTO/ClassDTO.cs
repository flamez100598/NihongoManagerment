using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentManagerment.BU.DTO
{
    public class ClassDTO
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public Nullable<int> ClassAmountStudent { get; set; }
        public Nullable<int> ClassCourseId { get; set; }

        public virtual CourseDTO CourseDTO { get; set; }

    }
}
