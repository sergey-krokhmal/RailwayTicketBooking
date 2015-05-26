using System;
using System.Collections.Generic;
using System.Linq;

namespace RailwayTicketBooking.Models
{
    public class AccountManager
    {
        public bool RegisterUser(RegistrationData regData)
        {
            Railway de = new Railway();
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

        public bool UserExist(string login)
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

        public int GetIdByLogin(string login)
        {
            Railway de = new Railway();   
            int userId = de.User.Where(u => u.Login == login).Select(u => u.Id).First();
            return userId;
        }

        public LoggedUser GetLoggedUserById(int id)
        {
            Railway rw = new Railway();
            User user = rw.User.Where(u => u.Id == id).First();
            return new LoggedUser(user.Id, user.Login, user.Password);
        }

        public LoggedUser GetLoggedUser(LoginViewModel loginData)
        {
            Railway rw = new Railway();
            List<User> users = rw.User.Where(u => u.Login == loginData.Login && u.Password == loginData.Password).ToList();
            if (users.Count == 0)
            {
                return null;
            }
            else
            {
                User u = users[0];
                return new LoggedUser(u.Id, u.Login, u.Password);
            }
        }
    }
}