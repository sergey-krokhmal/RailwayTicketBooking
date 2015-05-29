using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RailwayTicketBooking.Controllers
{
    [Authorize(Roles = "Admin, Moderator, User")]
    public class UserController : Controller
    {

        private RW rw= new RW();

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(rw.User.ToList());
        }

        [HttpGet]
        public ActionResult Profile(int id)
        {
            User user = rw.User.Find(id);
            return View(user);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            SelectList roles = new SelectList(rw.User_Role, "Id", "Name");
            ViewBag.Roles = roles;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                rw.User.Add(user);
                rw.SaveChanges();
                return RedirectToAction("Index");
            }
            SelectList roles = new SelectList(rw.User_Role, "Id", "Name");
            ViewBag.Roles = roles;
            return View(user);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            User user = rw.User.Find(id);
            SelectList roles = new SelectList(rw.User_Role, "Id", "Name", user.Id_User_Role);
            ViewBag.Roles = roles;
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                rw.Entry(user).State = EntityState.Modified;
                rw.SaveChanges();
                return RedirectToAction("Index");
            }
            SelectList roles = new SelectList(rw.User_Role, "Id", "Name", user.Id_User_Role);
            ViewBag.Roles = roles;
            return View(user);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Remove(int id)
        {
            User user = rw.User.Find(id);
            rw.User.Remove(user);
            rw.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
