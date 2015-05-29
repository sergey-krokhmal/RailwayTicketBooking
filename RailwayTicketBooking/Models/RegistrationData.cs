using System.ComponentModel.DataAnnotations;

namespace RailwayTicketBooking.Models
{
    public class RegistrationData
    {
        [Required(ErrorMessage = "Поле Логин обязательное")]
        [Display(Name = "Логин")]
        public string RegLogin { get; set; }

        [Required(ErrorMessage = "Поле Пароль обязательное")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string RegPassword { get; set; }

        [Required(ErrorMessage = "Поле Повторить пароль обязательное")]
        [DataType(DataType.Password)]
        [Display(Name = "Повторить пароль")]
        public string PasswordReplay { get; set; }

        [Required(ErrorMessage = "Поле Фамилия обязательное")]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Поле Имя обязательное")]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле Отчество обязательное")]
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }

        [Display(Name = "Телефонный номер")]
        public string Phone_Number { get; set; }

        [Display(Name = "Сер. и номер паспорта")]
        public string Passport_Num { get; set; }

        [Required(ErrorMessage = "Поле E-mail обязательное")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }


    }
}