using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Test.FV;

namespace Test.Areas.Admin.Models
{
    public class ChagePasswordModel : DbConnection
    {
        private readonly TourDLContext context = null;
        public ChagePasswordModel()
        {
            context = new TourDLContext();
        }

        public List<NhanVien> ListAll()
        {
            var list = context.Database.SqlQuery<NhanVien>("getnhanvien").ToList();
            return list;
        }

        public void chagePassNv(ChagePasswordModel cpass)
        {
            ketnoiproc("pr_chagepassNV");
            //cmd = new SqlCommand("pr_chagepassNV", _conn);
            //cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaNV", cpass.MaNV);
            cmd.Parameters.AddWithValue("@MatKhau", cpass.NewPassword);
            close_opensql();
        }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Mã nhân viên")]
        public string MaNV { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Mật khẩu hiện tại")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage ="Mật khẩu mới không đạt yêu cầu")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu mới")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Nhập lại mật khẩu mới")]
        [Compare("NewPassword", ErrorMessage = "Mật khẩu không khớp")]
        public string ConfirmPassword { get; set; }
    }
}