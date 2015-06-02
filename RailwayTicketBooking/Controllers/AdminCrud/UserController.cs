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

        private RW db= new RW();

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(db.User.ToList());
        }

        [HttpGet]
        public ActionResult Profile(int id)
        {
            User user = db.User.Find(id);
            return View(user);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            SelectList roles = new SelectList(db.User_Role, "Id", "Name");
            ViewBag.Roles = roles;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                db.User.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            SelectList roles = new SelectList(db.User_Role, "Id", "Name");
            ViewBag.Roles = roles;
            return View(user);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            User user = db.User.Find(id);
            SelectList roles = new SelectList(db.User_Role, "Id", "Name", user.Id_User_Role);
            ViewBag.Roles = roles;
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            SelectList roles = new SelectList(db.User_Role, "Id", "Name", user.Id_User_Role);
            ViewBag.Roles = roles;
            return View(user);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Remove(int id)
        {
            User user = db.User.Find(id);
            db.User.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
