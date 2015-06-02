using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RailwayTicketBooking.Controllers
{
    public class WagonController : Controller
    {
        private RW db = new RW();

        //
        // GET: /Wagon/

        public ActionResult Index()
        {
            var wagon = db.Wagon.Include(w => w.Train).Include(w => w.Wagon_Type);
            return View(wagon.ToList());
        }

        //
        // GET: /Wagon/Details/5

        public ActionResult Details(int id = 0)
        {
            Wagon wagon = db.Wagon.Find(id);
            if (wagon == null)
            {
                return HttpNotFound();
            }
            return View(wagon);
        }

        //
        // GET: /Wagon/Create

        public ActionResult Create()
        {
            ViewBag.Id_Train = new SelectList(db.Train, "Id", "Code");
            ViewBag.Id_Wagon_Type = new SelectList(db.Wagon_Type, "Id", "Name");
            return View();
        }

        //
        // POST: /Wagon/Create

        [HttpPost]
        public ActionResult Create(Wagon wagon)
        {
            if (ModelState.IsValid)
            {
                db.Wagon.Add(wagon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Train = new SelectList(db.Train, "Id", "Code", wagon.Id_Train);
            ViewBag.Id_Wagon_Type = new SelectList(db.Wagon_Type, "Id", "Name", wagon.Id_Wagon_Type);
            return View(wagon);
        }

        //
        // GET: /Wagon/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Wagon wagon = db.Wagon.Find(id);
            if (wagon == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Train = new SelectList(db.Train, "Id", "Code", wagon.Id_Train);
            ViewBag.Id_Wagon_Type = new SelectList(db.Wagon_Type, "Id", "Name", wagon.Id_Wagon_Type);
            return View(wagon);
        }

        //
        // POST: /Wagon/Edit/5

        [HttpPost]
        public ActionResult Edit(Wagon wagon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wagon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Train = new SelectList(db.Train, "Id", "Code", wagon.Id_Train);
            ViewBag.Id_Wagon_Type = new SelectList(db.Wagon_Type, "Id", "Name", wagon.Id_Wagon_Type);
            return View(wagon);
        }

        //
        // GET: /Wagon/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Wagon wagon = db.Wagon.Find(id);
            if (wagon == null)
            {
                return HttpNotFound();
            }
            return View(wagon);
        }

        //
        // POST: /Wagon/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Wagon wagon = db.Wagon.Find(id);
            db.Wagon.Remove(wagon);
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