using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RailwayTicketBooking.Models;
using RailwayTicketBooking.Models.BusinessObjects;

namespace RailwayTicketBooking.Controllers
{
    public class SearchTicketController : Controller
    {
        private RW db = new RW();
        //
        // GET: /SearchTicket/

        public ActionResult Index()
        {
            SelectList stations = new SelectList(db.Station, "Name", "Name");
            ViewBag.DepartureStations = stations;
            ViewBag.ArrivalStations = stations;
            return View();
        }

        [HttpPost]
        public ActionResult TrainList(SearchTicketViewModel stvm)
        {
            Session["stvm"] = stvm;
            ViewBag.stvm = stvm;
            TicketSearcher ts = new TicketSearcher();
            IList<TrainTicketViewModel> trainTickets = ts.GetTrainTicketList(stvm);
            return View(trainTickets);
        }

        [HttpGet]
        public ActionResult TicketList(object trainCode)
        {
            string tCode= ((string[])trainCode)[0];
            SearchTicketViewModel stvm = Session["stvm"] as SearchTicketViewModel;
            TicketSearcher ts = new TicketSearcher();
            IList<WagonTicketViewModel> wts = ts.GetWagonTicketList(stvm, tCode);
            ViewBag.Wts = wts;
            return View();
        }

        [HttpPost]
        public ActionResult TicketList(WagonTicketViewModel wt)
        {

            return RedirectToAction("Index", "Home");
        }



        public ActionResult AutocompleteStation(string term)
        {
            var authors = db.Station.Where(s => s.Name.Contains(term)).ToList().Select(s => new { value = s.Name });

            return Json(authors, JsonRequestBehavior.AllowGet);
        }
    }
}
