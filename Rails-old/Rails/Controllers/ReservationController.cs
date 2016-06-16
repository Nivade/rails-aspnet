using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rails.Models.View;


namespace Rails.Controllers
{
    public class ReservationController : Controller
    {
        // GET: Reservation
        public ActionResult Create(ReservationCreateViewModel model)
        {
            return View();
        }
    }
}