using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RailwayTicketBooking.Controllers
{
    public class TrainController : Controller
    {
        private RW db = new RW();

        //
        // GET: /Train/

        public ActionResult Index()
        {
            var train = db.Train.Include(t => t.Connection);
            return View(train.ToList());
        }

        //
        // GET: /Train/Details/5

        public ActionResult Details(short id = 0)
        {
            Train train = db.Train.Find(id);
            if (train == null)
            {
                return HttpNotFound();
            }
            return View(train);
        }

        //
        // GET: /Train/Create

        public ActionResult Create()
        {
            ViewBag.Id_Connection = new SelectList(db.Connection, "Id", "Id");
            return View();
        }

        //
        // POST: /Train/Create

        [HttpPost]
        public ActionResult Create(Train train)
        {
            if (ModelState.IsValid)
            {
                db.Train.Add(train);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Connection = new SelectList(db.Connection, "Id", "Id", train.Id_Connection);
            return View(train);
        }

        //
        // GET: /Train/Edit/5

        public ActionResult Edit(short id = 0)
        {
            Train train = db.Train.Find(id);
            if (train == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Connection = new SelectList(db.Connection, "Id", "Id", train.Id_Connection);
            return View(train);
        }

        //
        // POST: /Train/Edit/5

        [HttpPost]
        public ActionResult Edit(Train train)
        {
            if (ModelState.IsValid)
            {
                db.Entry(train).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Connection = new SelectList(db.Connection, "Id", "Id", train.Id_Connection);
            return View(train);
        }

        //
        // GET: /Train/Delete/5

        public ActionResult Delete(short id = 0)
        {
            Train train = db.Train.Find(id);
            if (train == null)
            {
                return HttpNotFound();
            }
            return View(train);
        }

        //
        // POST: /Train/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(short id)
        {
            Train train = db.Train.Find(id);
            db.Train.Remove(train);
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