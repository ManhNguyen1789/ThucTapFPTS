using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Test.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required]
        public int MaNV { set; get; }
        public string TaiKhoan { set; get; }
        public string PassWord { set; get; }
        public bool RememberMe { set; get; }
    }
}