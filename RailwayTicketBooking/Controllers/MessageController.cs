using RailwayTicketBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RailwayTicketBooking.Controllers
{
    public class MessageController : Controller
    {
        //
        // GET: /Message/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index(Message msg)
        {
            ViewBag.Title = msg.Title;
            return View(msg);
        }
    }
}
