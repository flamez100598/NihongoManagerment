using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentManagerment.BU.DTO
{
    public class RegisterManagermentDTO
    {
        public int register_id { get; set; }
        public string register_name { get; set; }
        public string register_phone { get; set; }
        public string register_email { get; set; }
        public int? register_course { get; set; }
        public int? register_status { get; set; }
    }
}
