using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RailwayTicketBooking.Controllers
{
    public class WagonTypeController : Controller
    {
        private RW db = new RW();

        //
        // GET: /WagonType/

        public ActionResult Index()
        {
            return View(db.Wagon_Type.ToList());
        }

        //
        // GET: /WagonType/Details/5

        public ActionResult Details(byte id = 0)
        {
            Wagon_Type wagon_type = db.Wagon_Type.Find(id);
            if (wagon_type == null)
            {
                return HttpNotFound();
            }
            return View(wagon_type);
        }

        //
        // GET: /WagonType/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /WagonType/Create

        [HttpPost]
        public ActionResult Create(Wagon_Type wagon_type)
        {
            if (ModelState.IsValid)
            {
                db.Wagon_Type.Add(wagon_type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wagon_type);
        }

        //
        // GET: /WagonType/Edit/5

        public ActionResult Edit(byte id = 0)
        {
            Wagon_Type wagon_type = db.Wagon_Type.Find(id);
            if (wagon_type == null)
            {
                return HttpNotFound();
            }
            return View(wagon_type);
        }

        //
        // POST: /WagonType/Edit/5

        [HttpPost]
        public ActionResult Edit(Wagon_Type wagon_type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wagon_type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wagon_type);
        }

        //
        // GET: /WagonType/Delete/5

        public ActionResult Delete(byte id = 0)
        {
            Wagon_Type wagon_type = db.Wagon_Type.Find(id);
            if (wagon_type == null)
            {
                return HttpNotFound();
            }
            return View(wagon_type);
        }

        //
        // POST: /WagonType/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(byte id)
        {
            Wagon_Type wagon_type = db.Wagon_Type.Find(id);
            db.Wagon_Type.Remove(wagon_type);
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