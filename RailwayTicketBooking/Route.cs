//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RailwayTicketBooking
{
    using System;
    using System.Collections.Generic;
    
    public partial class Route
    {
        public Route()
        {
            this.Ticket = new HashSet<Ticket>();
        }
    
        public int Id { get; set; }
        public int Id_Connection { get; set; }
        public System.TimeSpan Departure_Time { get; set; }
        public System.TimeSpan Driving_Time { get; set; }
        public decimal Cost { get; set; }
    
        public virtual Connection Connection { get; set; }
        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}