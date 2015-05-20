using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RailwayTicketBooking.Models
{
    public class ErrorMessageProvider
    {
        public static string GetErrorMessage(int errorCode)
        {
            switch(errorCode)
            {
                case 0:
                    return null;
                case 1:
                    return "Пароли не совпадают";
                case 2:
                    return 
                default:
                    return "Неизвестная ошибка. Обратитесь в техническую поддержку";
            }
        }
    }
}