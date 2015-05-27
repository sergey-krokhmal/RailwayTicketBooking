using System.ComponentModel.DataAnnotations;

namespace RailwayTicketBooking.Models
{
    public class LoginViewModel
    {
        [Display(Name = "Логин")]
        public string Login { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить меня")]
        public bool RememberMe { get; set; }
    }
}