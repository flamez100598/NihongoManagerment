using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentManagerment.BU.DTO
{
    public class RevenueDTO
    {
        public string ClassName { get; set; }
        public int TotalPrice { get; set; } //Tổng phải thu
        public int FinishPrice { get; set; } // Đã thu
        public int InDebt { get; set; } // Chưa thu
    }
}
