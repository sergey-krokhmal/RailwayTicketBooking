using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RailwayTicketBooking.Controllers
{
    public class UserRoleController : Controller
    {
        private RW db = new RW();

        //
        // GET: /UserRole/

        public ActionResult Index()
        {
            return View(db.User_Role.ToList());
        }

        //
        // GET: /UserRole/Details/5

        public ActionResult Details(byte id = 0)
        {
            User_Role user_role = db.User_Role.Find(id);
            if (user_role == null)
            {
                return HttpNotFound();
            }
            return View(user_role);
        }

        //
        // GET: /UserRole/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /UserRole/Create

        [HttpPost]
        public ActionResult Create(User_Role user_role)
        {
            if (ModelState.IsValid)
            {
                db.User_Role.Add(user_role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user_role);
        }

        //
        // GET: /UserRole/Edit/5

        public ActionResult Edit(byte id = 0)
        {
            User_Role user_role = db.User_Role.Find(id);
            if (user_role == null)
            {
                return HttpNotFound();
            }
            return View(user_role);
        }

        //
        // POST: /UserRole/Edit/5

        [HttpPost]
        public ActionResult Edit(User_Role user_role)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_role).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user_role);
        }

        //
        // GET: /UserRole/Delete/5

        public ActionResult Delete(byte id = 0)
        {
            User_Role user_role = db.User_Role.Find(id);
            if (user_role == null)
            {
                return HttpNotFound();
            }
            return View(user_role);
        }

        //
        // POST: /UserRole/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(byte id)
        {
            User_Role user_role = db.User_Role.Find(id);
            db.User_Role.Remove(user_role);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}