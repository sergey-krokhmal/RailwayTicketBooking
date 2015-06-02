using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RailwayTicketBooking.Controllers
{
    public class RouteController : Controller
    {
        private RW db = new RW();

        //
        // GET: /Route/

        public ActionResult Index()
        {
            var route = db.Route.Include(r => r.Connection);
            return View(route.ToList());
        }

        //
        // GET: /Route/Details/5

        public ActionResult Details(int id = 0)
        {
            Route route = db.Route.Find(id);
            if (route == null)
            {
                return HttpNotFound();
            }
            return View(route);
        }

        //
        // GET: /Route/Create

        public ActionResult Create()
        {
            ViewBag.Id_Connection = new SelectList(db.Connection, "Id", "Id");
            return View();
        }

        //
        // POST: /Route/Create

        [HttpPost]
        public ActionResult Create(Route route)
        {
            if (ModelState.IsValid)
            {
                db.Route.Add(route);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Connection = new SelectList(db.Connection, "Id", "Id", route.Id_Connection);
            return View(route);
        }

        //
        // GET: /Route/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Route route = db.Route.Find(id);
            if (route == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Connection = new SelectList(db.Connection, "Id", "Id", route.Id_Connection);
            return View(route);
        }

        //
        // POST: /Route/Edit/5

        [HttpPost]
        public ActionResult Edit(Route route)
        {
            if (ModelState.IsValid)
            {
                db.Entry(route).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Connection = new SelectList(db.Connection, "Id", "Id", route.Id_Connection);
            return View(route);
        }

        //
        // GET: /Route/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Route route = db.Route.Find(id);
            if (route == null)
            {
                return HttpNotFound();
            }
            return View(route);
        }

        //
        // POST: /Route/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Route route = db.Route.Find(id);
            db.Route.Remove(route);
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