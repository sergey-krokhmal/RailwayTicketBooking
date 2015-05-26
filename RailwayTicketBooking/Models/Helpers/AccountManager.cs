using System;
using System.Linq;

namespace RailwayTicketBooking.Models
{
    public class AccountManager
    {
        public static bool RegisterUser(RegistrationData regData)
        {
            RW de = new RW();
            if (regData.Password != regData.PasswordReplay)
            {
                throw new Exception("Пароли не совпадают");
            }
            if (!UserExist(regData.Login))
            {
                User user = new User();
                user.Id_UserRole = UserRole.GetIdByName(UserRoles.User.ToString());
                user.Login = regData.Login;
                user.Password = regData.Password;
                user.Name = regData.Name;
                user.Surname = regData.Surname;
                user.Patronymic = regData.Patronymic;
                de.User.Add(user);
                if (de.SaveChanges() > 0)
                {
                    return true;
                }
            }
            else
            {
                throw new Exception("Пользователь с таким логином уже существует");
            }
            return false;
        }

        public static bool UserExist(string login)
        {
            RW de = new RW();
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