using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RailwayTicketBooking.Models;

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
            var tickets = db.Ticket.Where(t =>
                t.Departure_Date == stvm.DepartureDate &&
                t.Route.Connection.Station1.Name == stvm.DepartureStation &&
                t.Route.Connection.Station.Name == stvm.ArrivalStation);
            var trains = db.Train.Join(tickets, tr => tr.Id, ti=>ti.Wagon.Id_Train, (tr,ti)=> tr).Distinct();
            List<TrainTicketViewModel> trainTickets = new List<TrainTicketViewModel>();
            foreach (Train train in trains)
            {
                TrainTicketViewModel tt = new TrainTicketViewModel();
                var ticks = tickets.Where(ti=>ti.Wagon.Id_Train == train.Id);
                var ticket = ticks.First();
                tt.ArrDate = (ticket.Departure_Date + ticket.Route.Departure_Time + ticket.Route.Driving_Time).Date.ToShortDateString();
                tt.ArrStation = stvm.ArrivalStation;
                tt.ArrTime = (ticket.Departure_Date + ticket.Route.Driving_Time).ToString("HH:mm");
                tt.DepStation = stvm.DepartureStation;
                tt.DepDate = stvm.DepartureDate.ToShortDateString();
                tt.DepTime = ticket.Route.Departure_Time.ToString(@"hh\:mm");
                tt.DriveTime = ticket.Route.Driving_Time.ToString(@"hh\:mm");
                tt.TicketCount = ticks.Count();
                tt.Train = train;
                trainTickets.Add(tt);
            }
            return View(trainTickets);
        }

        [HttpGet]
        public ActionResult TicketList(string trainCode)
        {
            SearchTicketViewModel stvm = Session["stvm"] as SearchTicketViewModel;
            var tickets = db.Ticket.Where(t =>
                t.Departure_Date == stvm.DepartureDate &&
                t.Route.Connection.Station1.Name == stvm.DepartureStation &&
                t.Route.Connection.Station.Name == stvm.ArrivalStation &&
                t.Wagon.Train.Code == trainCode);
            var wagons = tickets.Select(t => t.Wagon).Distinct();
            return View(trainCode);
        }

        public ActionResult AutocompleteStation(string term)
        {
            var authors = db.Station.Where(s => s.Name.Contains(term)).ToList().Select(s => new { value = s.Name });

            return Json(authors, JsonRequestBehavior.AllowGet);
        }
    }
}
