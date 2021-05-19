
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Test.FV;

namespace Test.Areas.Admin.Models
{
    public class AcountLogin
    {
        private readonly TourDLContext context = null;
        public AcountLogin()
        {
            context = new TourDLContext();
        }
        public bool Login(string TaiKhoan, string PassWord)
        {
            var sqlParams = new SqlParameter[]{
                new SqlParameter("@tk",TaiKhoan),
                new SqlParameter("@mk",PassWord),
            };
            var res = context.Database.SqlQuery<bool>("acount @tk, @mk", sqlParams).SingleOrDefault();
            return res;
        }
    }
}