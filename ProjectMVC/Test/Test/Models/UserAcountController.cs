using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.Models
{
    public class UserAcountController : Controller
    {
        // GET: UserAcount
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserAcount/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserAcount/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserAcount/Create
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

        // GET: UserAcount/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserAcount/Edit/5
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

        // GET: UserAcount/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserAcount/Delete/5
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
