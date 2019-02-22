using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentManagerment.BU.DTO
{
    public class LoginModelDTO
    {
        [Required(ErrorMessage ="Nhập tên tài khoản")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Nhập mật khẩu tài khoản")]
        public string UserPassword { get; set; }
    }
}
