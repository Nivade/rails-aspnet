using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rails.Controllers
{
    public class CleaningController : Controller
    {
        // GET: Reservation
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult Pending()
        {

            return View();
        }

        public ActionResult Schedule()
        {

            return View();
        }
    }
}