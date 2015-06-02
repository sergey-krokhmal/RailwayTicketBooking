using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RailwayTicketBooking.Controllers
{
    public class StationController : Controller
    {
        private RW db = new RW();

        //
        // GET: /Station/

        public ActionResult Index()
        {
            return View(db.Station.ToList());
        }

        //
        // GET: /Station/Details/5

        public ActionResult Details(short id = 0)
        {
            Station station = db.Station.Find(id);
            if (station == null)
            {
                return HttpNotFound();
            }
            return View(station);
        }

        //
        // GET: /Station/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Station/Create

        [HttpPost]
        public ActionResult Create(Station station)
        {
            if (ModelState.IsValid)
            {
                db.Station.Add(station);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(station);
        }

        //
        // GET: /Station/Edit/5

        public ActionResult Edit(short id = 0)
        {
            Station station = db.Station.Find(id);
            if (station == null)
            {
                return HttpNotFound();
            }
            return View(station);
        }

        //
        // POST: /Station/Edit/5

        [HttpPost]
        public ActionResult Edit(Station station)
        {
            if (ModelState.IsValid)
            {
                db.Entry(station).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(station);
        }

        //
        // GET: /Station/Delete/5

        public ActionResult Delete(short id = 0)
        {
            Station station = db.Station.Find(id);
            if (station == null)
            {
                return HttpNotFound();
            }
            return View(station);
        }

        //
        // POST: /Station/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(short id)
        {
            Station station = db.Station.Find(id);
            db.Station.Remove(station);
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