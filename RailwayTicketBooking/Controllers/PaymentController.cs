using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RailwayTicketBooking.Controllers
{
    public class PaymentController : Controller
    {
        //
        // GET: /Payment/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Pay(string str)
        {
            return RedirectToAction("Index", "Message", new { title = "qwe", body = "sdf" });
        }
    }
}
