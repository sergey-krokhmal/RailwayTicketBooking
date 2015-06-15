using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RailwayTicketBooking.Models.BusinessObjects
{
    public abstract class PaymentSystem
    {
        public string Name {get; set;}
        public double Amount { get; set; }
        public abstract void Post();
    }
}