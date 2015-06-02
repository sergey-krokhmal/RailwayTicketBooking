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
                user.Id_User_Role = UserRole.GetRoleId(UserRoles.User);
                user.Login = regData.RegLogin;
                user.Password = regData.RegPassword;
                user.Name = regData.Name;
                user.Surname = regData.Surname;
                user.Patronymic = regData.Patronymic;
                user.Address = regData.Address;
                user.Email = regData.Email;
                user.IsActive = true;
                user.Phone_Number = regData.Phone_Number;
                user.Passport_Num = regData.Passport_Num;
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

        public LoggedUser GetLoggedUserByLogin(string login)
        {
            RW db = new RW();
            User user = db.User.Where(u => u.Login == login).First();
            return new LoggedUser(user.Id, user.Login, user.Surname, user.Name);
        }

        public LoggedUser GetLoggedUser(LoginViewModel loginData)
        {
            RW db = new RW();
            List<User> users = db.User.Where(u => u.Login == loginData.Login && u.Password == loginData.Password).ToList();
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