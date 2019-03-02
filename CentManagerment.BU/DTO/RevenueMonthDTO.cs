using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentManagerment.BU.DTO
{
    public class RevenueMonthDTO
    {
        public int Id { get; set; }
        public int? ClassId { get; set; }
        public int? Period { get; set; }
        public DateTime? Time { get; set; }

        public virtual ClassDTO ClassDTO { get; set; }

        //
        public decimal? Money { set; get; }

        public int Year { get; set; }
        public int Month { get; set; }

    }
}
