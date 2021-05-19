using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Areas.Admin.Models;
using Test.FV;

namespace Test.Areas.Admin.Controllers
{
    public class NhanVienController : Controller
    {
        
        // GET: Admin/NhanVien
        public ActionResult Index()
        {
            if (Session["user"]==null)
            {
                return RedirectToAction("Index", "LoginAdmin", "Admin");
            }
            else
            {
                var iplCate = new NhanVienModel();
                var model = iplCate.ListAll();
                
                ViewBag.NAME = Session["user"].ToString();
                return View(model);
            }
        }

        public ActionResult Search(string timkiem)
        {
            var iplCate = new NhanVienModel();
            var model = iplCate.danhsachtimkiem(timkiem);
            return View(model);
        }
        
        // GET: Admin/NhanVien/Details/5
        public ActionResult Details(string id)
        {
            var iplCate = new NhanVienModel();
            var model = iplCate.ListAll();

            return View(model.FirstOrDefault(x => x.MaNV == id));
        }

        // GET: Admin/NhanVien/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NhanVien/Create
        [HttpPost]
        public ActionResult Create(NhanVien nv)
        {
            try
            {
                // TODO: Add insert logic here
                var nvien = new NhanVienModel();
                nvien.Addnhanvien(nv);
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/NhanVien/Edit/5
        public ActionResult Edit(string id)
        {
            var iplCate = new NhanVienModel();
            var model = iplCate.ListAll();
            
            return View(model.FirstOrDefault(x => x.MaNV == id));
        }

        // POST: Admin/NhanVien/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, NhanVien nv)
        {
            try
            {


            //TODO: Add update logic here
                if (id == null)
                {
                    return RedirectToAction("Index");
                }
                else
                {

                    var nvien = new NhanVienModel();
                    nvien.Editnhanvien(nv);
                    return RedirectToAction("Index");
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/NhanVien/Delete/5
        public ActionResult Delete(string id)
        {
            var iplCate = new NhanVienModel();
            var model = iplCate.ListAll();

            return View(model.FirstOrDefault(x => x.MaNV == id));
        }

        // POST: Admin/NhanVien/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, NhanVien nv)
        {
            try
            {
                if (id == null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    // TODO: Add delete logic here
                    var nvien = new NhanVienModel();
                    nv = new NhanVien();

                    nv.MaNV = id;
                    nvien.deletenhanvien(nv);

                    return RedirectToAction("Index", "NhanVien", "Admin");
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Chagepass(string id)
        {
            var iplCate = new NhanVienModel();
            var model = iplCate.ListAll();

            return View(model.FirstOrDefault(x => x.MaNV == id));
        }

        // POST: Admin/NhanVien/Delete/5
        [HttpPost]
        public ActionResult Chagepass(string id, ChagePasswordModel cp)
        {
            try
            {
                if (id == null)
                {
                    return RedirectToAction("Index", "NhanVien", "Admin");
                }
                else
                {
                    // TODO: Add delete logic here
                    var nvien = new ChagePasswordModel();
                    if (cp.NewPassword == cp.ConfirmPassword)
                    {
                        nvien.chagePassNv(cp);
                    }
                    else
                    {
                        HttpContext.Response.Write("<script>alert('Lỗi không thể đổi mật khẩu');</script>");
                    }
                }
                return RedirectToAction("Index", "NhanVien", "Admin");
            }
            catch
            {
                return View();
            }
        }
    }
}
