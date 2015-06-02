using System;
using System.ComponentModel.DataAnnotations;

namespace RailwayTicketBooking.Models
{
    public class SearchTicketViewModel
    {
        [Required(ErrorMessage = "Нужно указать станцию отправления")]
        [Display(Name = "Станция отправления")]
        public string DepartureStation { get; set; }

        [Required(ErrorMessage = "Нужно указать станцию прибытия")]
        [Display(Name = "Станция прибытия")]
        public string ArrivalStation { get; set; }

        [Required(ErrorMessage = "Нужно указать станцию прибытия")]
        [Display(Name = "Дата отправления")]
        public DateTime DepartureDate { get; set; }
    }
}