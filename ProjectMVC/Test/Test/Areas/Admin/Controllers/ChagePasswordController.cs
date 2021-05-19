using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Areas.Admin.Models;

namespace Test.Areas.Admin.Controllers
{
    public class ChagePasswordController : Controller
    {
        // GET: Admin/ChagePassword
        public ActionResult Index(string t)
        {
            var iplCate = new ChagePasswordModel();
            var model = iplCate.ListAll();

            return View(model.FirstOrDefault(x => x.MaNV == t));
        }
        public ActionResult Index(ChagePasswordModel cpass, string t)
        {
            try
            {
                // TODO: Add update logic here
                if (t == null)
                {
                    return RedirectToAction("Index");
                }
                else
                {

                    var nvien = new ChagePasswordModel();
                    nvien.chagePassNv(cpass);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/ChagePassword/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/ChagePassword/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ChagePassword/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/ChagePassword/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/ChagePassword/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/ChagePassword/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/ChagePassword/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
