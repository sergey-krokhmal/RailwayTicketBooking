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

        public MessageController() { }

        public ActionResult Index(string title, string body)
        {
            Message msg = new Message(title, body);
            return View(msg);
        }
    }
}
