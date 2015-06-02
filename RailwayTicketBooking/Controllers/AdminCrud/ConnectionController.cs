using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RailwayTicketBooking.Controllers
{
    public class ConnectionController : Controller
    {
        private RW db = new RW();

        //
        // GET: /Connection/

        public ActionResult Index()
        {
            var connection = db.Connection.Include(c => c.Station).Include(c => c.Station1);
            return View(connection.ToList());
        }

        //
        // GET: /Connection/Details/5

        public ActionResult Details(int id = 0)
        {
            Connection connection = db.Connection.Find(id);
            if (connection == null)
            {
                return HttpNotFound();
            }
            return View(connection);
        }

        //
        // GET: /Connection/Create

        public ActionResult Create()
        {
            ViewBag.Id_Arrival_Station = new SelectList(db.Station, "Id", "Name");
            ViewBag.Id_Departure_Station = new SelectList(db.Station, "Id", "Name");
            return View();
        }

        //
        // POST: /Connection/Create

        [HttpPost]
        public ActionResult Create(Connection connection)
        {
            if (ModelState.IsValid)
            {
                db.Connection.Add(connection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Arrival_Station = new SelectList(db.Station, "Id", "Name", connection.Id_Arrival_Station);
            ViewBag.Id_Departure_Station = new SelectList(db.Station, "Id", "Name", connection.Id_Departure_Station);
            return View(connection);
        }

        //
        // GET: /Connection/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Connection connection = db.Connection.Find(id);
            if (connection == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Arrival_Station = new SelectList(db.Station, "Id", "Name", connection.Id_Arrival_Station);
            ViewBag.Id_Departure_Station = new SelectList(db.Station, "Id", "Name", connection.Id_Departure_Station);
            return View(connection);
        }

        //
        // POST: /Connection/Edit/5

        [HttpPost]
        public ActionResult Edit(Connection connection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(connection).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Arrival_Station = new SelectList(db.Station, "Id", "Name", connection.Id_Arrival_Station);
            ViewBag.Id_Departure_Station = new SelectList(db.Station, "Id", "Name", connection.Id_Departure_Station);
            return View(connection);
        }

        //
        // GET: /Connection/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Connection connection = db.Connection.Find(id);
            if (connection == null)
            {
                return HttpNotFound();
            }
            return View(connection);
        }

        //
        // POST: /Connection/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Connection connection = db.Connection.Find(id);
            db.Connection.Remove(connection);
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