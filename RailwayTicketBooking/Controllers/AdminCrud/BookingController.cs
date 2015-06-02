using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RailwayTicketBooking.Controllers
{
    public class BookingController : Controller
    {
        private RW db = new RW();

        //
        // GET: /Booking/

        public ActionResult Index()
        {
            var booking = db.Booking.Include(b => b.Facility).Include(b => b.Ticket).Include(b => b.User);
            return View(booking.ToList());
        }

        //
        // GET: /Booking/Details/5

        public ActionResult Details(int id = 0)
        {
            Booking booking = db.Booking.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        //
        // GET: /Booking/Create

        public ActionResult Create()
        {
            ViewBag.Id_Facility = new SelectList(db.Facility, "Id", "Descript");
            ViewBag.Id_Ticket = new SelectList(db.Ticket, "Id", "Code");
            ViewBag.Id_User = new SelectList(db.User, "Id", "Surname");
            return View();
        }

        //
        // POST: /Booking/Create

        [HttpPost]
        public ActionResult Create(Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Booking.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Facility = new SelectList(db.Facility, "Id", "Descript", booking.Id_Facility);
            ViewBag.Id_Ticket = new SelectList(db.Ticket, "Id", "Code", booking.Id_Ticket);
            ViewBag.Id_User = new SelectList(db.User, "Id", "Surname", booking.Id_User);
            return View(booking);
        }

        //
        // GET: /Booking/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Booking booking = db.Booking.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Facility = new SelectList(db.Facility, "Id", "Descript", booking.Id_Facility);
            ViewBag.Id_Ticket = new SelectList(db.Ticket, "Id", "Code", booking.Id_Ticket);
            ViewBag.Id_User = new SelectList(db.User, "Id", "Surname", booking.Id_User);
            return View(booking);
        }

        //
        // POST: /Booking/Edit/5

        [HttpPost]
        public ActionResult Edit(Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Facility = new SelectList(db.Facility, "Id", "Descript", booking.Id_Facility);
            ViewBag.Id_Ticket = new SelectList(db.Ticket, "Id", "Code", booking.Id_Ticket);
            ViewBag.Id_User = new SelectList(db.User, "Id", "Surname", booking.Id_User);
            return View(booking);
        }

        //
        // GET: /Booking/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Booking booking = db.Booking.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        //
        // POST: /Booking/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Booking.Find(id);
            db.Booking.Remove(booking);
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