using System;
using System.Linq;

namespace RailwayTicketBooking.Models
{
    public class AccountManager
    {
        public static void RegisterUser(RegistrationData regData)
        {
            Railway de = new Railway();
            if (regData.Password != regData.PasswordReplay)
            {
                throw new Exception("Пароли не совпадают");
            }
            if (!UserExist(regData.Login))
            {
                User user = new User();
                user.Id_UserRole = 2;
                user.Login = regData.Login;
                user.Name = regData.Name;
                user.Password = regData.Password;
                de.User.Add(user);
            }
            else
            {
                throw new Exception("Пользователь с таким логином уже существует");
            }

        }

        public static bool UserExist(string login)
        {
            Railway de = new Railway();
            int userCount = de.User.Count(u => u.Login == login);
            if (userCount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}