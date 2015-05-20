using System;
using System.Linq;

namespace RailwayTicketBooking.Models
{
    public class AccountManager
    {
        public static void RegisterUser(LoginViewModel logModel)
        {
            Railway de = new Railway();
            if (!UserExist(logModel.Login))
            {
                User user = new User();
                user.Id_UserRole = 2;
                user.Login = logModel.Login;
                user.Name = logModel.Name;
                user.Password = logModel.Password;
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