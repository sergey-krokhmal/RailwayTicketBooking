using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RailwayTicketBooking.Controllers
{
    public class FacilityController : Controller
    {
        private RW db = new RW();

        //
        // GET: /Facility/

        public ActionResult Index()
        {
            return View(db.Facility.ToList());
        }

        //
        // GET: /Facility/Details/5

        public ActionResult Details(byte id = 0)
        {
            Facility facility = db.Facility.Find(id);
            if (facility == null)
            {
                return HttpNotFound();
            }
            return View(facility);
        }

        //
        // GET: /Facility/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Facility/Create

        [HttpPost]
        public ActionResult Create(Facility facility)
        {
            if (ModelState.IsValid)
            {
                db.Facility.Add(facility);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(facility);
        }

        //
        // GET: /Facility/Edit/5

        public ActionResult Edit(byte id = 0)
        {
            Facility facility = db.Facility.Find(id);
            if (facility == null)
            {
                return HttpNotFound();
            }
            return View(facility);
        }

        //
        // POST: /Facility/Edit/5

        [HttpPost]
        public ActionResult Edit(Facility facility)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facility).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(facility);
        }

        //
        // GET: /Facility/Delete/5

        public ActionResult Delete(byte id = 0)
        {
            Facility facility = db.Facility.Find(id);
            if (facility == null)
            {
                return HttpNotFound();
            }
            return View(facility);
        }

        //
        // POST: /Facility/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(byte id)
        {
            Facility facility = db.Facility.Find(id);
            db.Facility.Remove(facility);
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