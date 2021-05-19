using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Areas.Admin.Models;

namespace Test.Areas.Admin.Controllers
{
    public class TourController : Controller
    {
        // GET: Admin/Tour
        public ActionResult Index()
        {
            var iplCate = new TourModel();
            var model = iplCate.ListAll();
            return View(model);
        }

        // GET: Admin/Tour/Details/5
        public ActionResult Details(string id)
        {
            var iplCate = new TourModel();
            var model = iplCate.ListAll();

            return View(model.FirstOrDefault(x => x.MaTour == id));
        }

        // GET: Admin/Tour/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Tour/Create
        [HttpPost]
        public ActionResult Create(Tour t)
        {
            try
            {
                // TODO: Add insert logic here
                var tour = new TourModel();
                tour.Addtour(t);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Tour/Edit/5
        public ActionResult Edit(string id)
        {
            var iplCate = new TourModel();
            var model = iplCate.ListAll();

            return View(model.FirstOrDefault(x => x.MaTour == id));
        }

        // POST: Admin/Tour/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Tour t)
        {
            try
            {
                // TODO: Add update logic here

                if (id == null)
                {
                    return RedirectToAction("Index");
                }
                else
                {

                    var tour = new TourModel();
                    tour.Edittour(t);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Tour/Delete/5
        public ActionResult Delete(string id)
        {
            var iplCate = new TourModel();
            var model = iplCate.ListAll();

            return View(model.FirstOrDefault(x => x.MaTour == id));
        }

        // POST: Admin/Tour/Delete/5
        [HttpPost]
        public ActionResult Delete(string id,Tour t)
        {
            try
            {
                // TODO: Add delete logic here

                var tour = new TourModel();
                t = new Tour();
                t.MaTour = id;
                tour.deletetour(t);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
