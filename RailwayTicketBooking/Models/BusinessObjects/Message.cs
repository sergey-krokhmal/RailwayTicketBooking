using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RailwayTicketBooking.Models
{
    public class Message
    {
        public string Title { get; private set; }
        public string Body { get; private set; }

        public Message(string title, string body)
        {
            Title = title;
            Body = body;
        }
    }
}