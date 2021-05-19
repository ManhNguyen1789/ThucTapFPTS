using MVCFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFirst.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var message = new MessageModel();
            message.welcome = "chào mừng đến với model";
            return View();
        }
    }
}