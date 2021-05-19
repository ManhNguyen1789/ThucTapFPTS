using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Areas.Admin.Models;

namespace Test.Areas.Admin.Controllers
{
    public class BookingController : Controller
    {
        
        // GET: Admin/Booking
        public ActionResult Index()
        {
            var iplCate = new BookingModel();
            var model = iplCate.ListAll();
            return View(model);
        }

        // GET: Admin/Booking/Details/5
        public ActionResult Details(int id)
        {
            var book = new BookingModel();
            var model = book.ListAll();

            return View(model.FirstOrDefault(x => x.MaVe == id));
        }

        // GET: Admin/Booking/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Booking/Create
        [HttpPost]
        public ActionResult Create(Booking bk)
        {
            try
            {
                // TODO: Add insert logic here
                var book = new BookingModel();
                book.Addbooking(bk);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Booking/Edit/5
        public ActionResult Edit(int id)
        {
            var book = new BookingModel();
            var model = book.ListAll();

            return View(model.FirstOrDefault(x => x.MaVe == id));
        }

        // POST: Admin/Booking/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Booking bk)
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

                    var nvien = new BookingModel();
                    nvien.Editbooking(bk);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Booking/Delete/5
        public ActionResult Delete(int id)
        {
            var iplCate = new BookingModel();
            var model = iplCate.ListAll();

            return View(model.FirstOrDefault(x => x.MaVe == id));
        }

        // POST: Admin/Booking/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Booking bk)
        {
            try
            {
                // TODO: Add delete logic here

                var book = new BookingModel();
                bk = new Booking();

                bk.MaVe = id;
                book.deletebooking(bk);

                return RedirectToAction("Index", "Booking");
            }
            catch
            {
                return View();
            }
        }
    }
}
