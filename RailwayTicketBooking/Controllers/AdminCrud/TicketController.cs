using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RailwayTicketBooking.Controllers
{
    public class TicketController : Controller
    {
        private RW db = new RW();

        //
        // GET: /Ticket/

        public ActionResult Index()
        {
            var ticket = db.Ticket.Include(t => t.Booking).Include(t => t.Route).Include(t => t.Wagon);
            return View(ticket.ToList());
        }

        //
        // GET: /Ticket/Details/5

        public ActionResult Details(int id = 0)
        {
            Ticket ticket = db.Ticket.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        //
        // GET: /Ticket/Create

        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Booking, "Id_Ticket", "Id_Ticket");
            ViewBag.Id_Route = new SelectList(db.Route, "Id", "Id");
            ViewBag.Id_Wagon = new SelectList(db.Wagon, "Id", "Id");
            return View();
        }

        //
        // POST: /Ticket/Create

        [HttpPost]
        public ActionResult Create(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Ticket.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Booking, "Id_Ticket", "Id_Ticket", ticket.Id);
            ViewBag.Id_Route = new SelectList(db.Route, "Id", "Id", ticket.Id_Route);
            ViewBag.Id_Wagon = new SelectList(db.Wagon, "Id", "Id", ticket.Id_Wagon);
            return View(ticket);
        }

        //
        // GET: /Ticket/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Ticket ticket = db.Ticket.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Booking, "Id_Ticket", "Id_Ticket", ticket.Id);
            ViewBag.Id_Route = new SelectList(db.Route, "Id", "Id", ticket.Id_Route);
            ViewBag.Id_Wagon = new SelectList(db.Wagon, "Id", "Id", ticket.Id_Wagon);
            return View(ticket);
        }

        //
        // POST: /Ticket/Edit/5

        [HttpPost]
        public ActionResult Edit(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Booking, "Id_Ticket", "Id_Ticket", ticket.Id);
            ViewBag.Id_Route = new SelectList(db.Route, "Id", "Id", ticket.Id_Route);
            ViewBag.Id_Wagon = new SelectList(db.Wagon, "Id", "Id", ticket.Id_Wagon);
            return View(ticket);
        }

        //
        // GET: /Ticket/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Ticket ticket = db.Ticket.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        //
        // POST: /Ticket/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket ticket = db.Ticket.Find(id);
            db.Ticket.Remove(ticket);
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