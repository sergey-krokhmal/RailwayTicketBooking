using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RailwayTicketBooking.Models.BusinessObjects
{
    public class TicketSearcher
    {
        private RW db = new RW();
        
        public IList<TrainTicketViewModel> GetTrainTicketList(SearchTicketViewModel stvm)
        {
            var tickets = db.Ticket.Where(t =>
                t.Departure_Date == stvm.DepartureDate &&
                t.Route.Connection.Station1.Name == stvm.DepartureStation &&
                t.Route.Connection.Station.Name == stvm.ArrivalStation);
            var trains = db.Train.Join(tickets, tr => tr.Id, ti => ti.Wagon.Id_Train, (tr, ti) => tr).Distinct();
            List<TrainTicketViewModel> trainTickets = new List<TrainTicketViewModel>();
            foreach (Train train in trains)
            {
                TrainTicketViewModel tt = new TrainTicketViewModel();
                var ticks = tickets.Where(ti => ti.Wagon.Id_Train == train.Id);
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
            return trainTickets;
        }

        public IList<WagonTicketViewModel> GetWagonTicketList(SearchTicketViewModel stvm, string trainCode)
        {
            var tickets = db.Ticket.Where(t =>
                t.Departure_Date == stvm.DepartureDate &&
                t.Route.Connection.Station1.Name == stvm.DepartureStation &&
                t.Route.Connection.Station.Name == stvm.ArrivalStation &&
                t.Wagon.Train.Code == trainCode);
            var wagons = tickets.Select(t => t.Wagon).Distinct();
            IList<WagonTicketViewModel> wts = new List<WagonTicketViewModel>(wagons.Count());
            foreach (Wagon w in wagons)
            {
                var wTickets = w.Ticket.Where(t =>
                    t.Id_Wagon == w.Id);
                WagonTicketViewModel wt = new WagonTicketViewModel();
                wt.TicketCount = wTickets.Count();
                wt.WagonNumber = w.Number;
                wt.PlaceNumbers = new List<int>();
                foreach (Ticket t in wTickets)
                {
                    wt.PlaceNumbers.Add(t.Place_Number);
                }
                wts.Add(wt);
            }
            return wts;
        }
    }
}