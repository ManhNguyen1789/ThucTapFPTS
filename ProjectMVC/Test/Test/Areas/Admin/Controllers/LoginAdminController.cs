using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Areas.Admin.Models;
using Test.Areas.Admin.code;

namespace Test.Areas.Admin.Controllers
{
    public class LoginAdminController : Controller
    {
        // GET: Admin/Login
        //httlget  có thể nhận từ url
        
        //code.acess data = new code.acess();
        public ActionResult Index()
        {
            if (Session["user"] != null)
            {
                return RedirectToAction("Index", "HomeAdmin", "Admin");
            }
            return View();
        }

        //không thể nhận từ url
        [HttpPost]
        //public ActionResult Index(FormCollection fc)
        //{
        //    try
        //    {
        //        int res = data.LoginAdmin(fc["username"], fc["password"]);
        //        if (res == 1)
        //        {
        //            return RedirectToAction("IndexHomeAd", "HomeAdmin");

        //        }
        //        else
        //        {
        //            TempData["msg"] = "tài khoảng mật khẩu không chính xác";
        //        }
        //        return View();
        //    }
        //    catch
        //    {
        //        TempData["msg"] = "lỗi không thể đăng nhập";
        //    }
        //    return null;
        //}
        /*sinh ra một token xác thực để đảm bảo đã login chánh việc req liên tục*/
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
           
            var result = new AcountLogin().Login(model.TaiKhoan, PassMd5.CreateMD5(model.PassWord));
            if (result && ModelState.IsValid)
            {
                //SessionHelper.SetSession(new UserSession() { UserName = model.TaiKhoan });
                Session["user"] = model.TaiKhoan;
                return RedirectToAction("Index", "HomeAdmin", "Admin");
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc tài khoản không chính xác!");
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "LoginAdmin", "Admin");
        }
    }

    
}