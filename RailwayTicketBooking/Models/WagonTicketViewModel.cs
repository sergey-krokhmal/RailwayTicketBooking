using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RailwayTicketBooking.Models
{
    public class WagonTicketViewModel
    {
        public int WagonNumber { get; set; }
        public int TicketCount { get; set; }
        public IList<int> PlaceNumbers { get; set; }
    }
}