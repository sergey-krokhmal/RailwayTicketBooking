using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RailwayTicketBooking.Models
{
    public class TrainTicketViewModel
    {
        public Train Train { get; set; }
        public string DepStation { get; set; }
        public string ArrStation { get; set; }
        public int TicketCount { get; set; }
        public string DepDate { get; set; }
        public string DepTime { get; set; }
        public string DriveTime { get; set; }
        public string ArrTime { get; set; }
        public string ArrDate { get; set; }
    }
}