using System;
using System.Collections.Generic;
using System.Linq;

namespace RailwayTicketBooking.Models
{
    public class AccountManager
    {
        public bool RegisterUser(RegistrationData regData)
        {
            RW de = new RW();
            if (regData.RegPassword != regData.PasswordReplay)
            {
                throw new Exception("Пароли не совпадают");
            }
            if (!UserExist(regData.RegLogin))
            {
                User user = new User();
                user.Id_User_Role = UserRole.GetIdByName(UserRoles.User.ToString());
                user.Login = regData.RegLogin;
                user.Password = regData.RegPassword;
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

        public int GetIdByLogin(string login)
        {
            RW de = new RW();   
            int userId = de.User.Where(u => u.Login == login).Select(u => u.Id).First();
            return userId;
        }

        public LoggedUser GetLoggedUserById(int id)
        {
            RW rw = new RW();
            User user = rw.User.Find(id);
            return new LoggedUser(user.Id, user.Login, user.Surname, user.Name);
        }

        public LoggedUser GetLoggedUser(LoginViewModel loginData)
        {
            RW rw = new RW();
            List<User> users = rw.User.Where(u => u.Login == loginData.Login && u.Password == loginData.Password).ToList();
            if (users.Count == 0)
            {
                return null;
            }
            else
            {
                User u = users[0];
                return new LoggedUser(u.Id, u.Login, u.Surname, u.Name);
            }
        }
    }
}