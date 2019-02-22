using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentManagerment.BU.DTO
{
    public class ExpenditureDTO
    {

        public int ExpenditureId { get; set; }
        public string ExpenditureName { get; set; }
        public Nullable<int> Price { get; set; }

        public virtual ICollection<RevenueDTO> RevenueDTO { get; set; }
    }
}
