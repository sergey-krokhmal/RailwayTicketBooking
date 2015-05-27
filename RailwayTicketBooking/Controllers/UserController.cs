using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RailwayTicketBooking.Controllers
{
    [Authorize(Roles = "Admin, Moderator")]
    public class UserController : Controller
    {

        private RW rw= new RW();

        public ActionResult Index()
        {
            return View(rw.User);
        }

    }
}
