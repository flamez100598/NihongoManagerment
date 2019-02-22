using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentManagerment.BU.DTO
{
    public class NewsDTO
    {
        public int NewsId { get; set; }
        public string NewsContent { get; set; }
        public string NewsShortContent { get; set; }
        public DateTime? NewsPostDate { get; set; }
        public string NewsTitle { get; set; }
        public int? NewsUserID { get; set; }
        public string NewsAvatar { get; set; }
        public string NewsNameUserPost { get; set; }


        public virtual UserManagerDTO UserManagerDTO { get; set; }


    }
}
