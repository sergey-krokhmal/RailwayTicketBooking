using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace RailwayTicketBooking.Providers
{
    public class UserRoleProvider: RoleProvider
    {
        public override string[] GetRolesForUser(string login)
        {
            string[] role = new string[] { };
            using (RW db = new RW())
            {
                try
                {
                    // Получаем пользователя
                    User user = db.User.Where(u => u.Login == login).First();
                    if (user != null)
                    {
                        // получаем роль
                        User_Role userRole = db.User_Role.Find(user.Id_User_Role);

                        if (userRole != null)
                        {
                            role = new string[] { userRole.Name };
                        }
                    }
                }
                catch
                {
                    role = new string[] { };
                }
            }
            return role;
        }
        public override bool IsUserInRole(string username, string roleName)
        {
            bool outputResult = false;
            // Находим пользователя
            using (RW db = new RW())
            {
                try
                {
                    // Получаем пользователя
                    User user = (from u in db.User
                                 where u.Login == username
                                 select u).FirstOrDefault();
                    if (user != null)
                    {
                        // получаем роль
                        User_Role userRole = db.User_Role.Find(user.Id_User_Role);

                        //сравниваем
                        if (userRole != null && userRole.Name == roleName)
                        {
                            outputResult = true;
                        }
                    }
                }
                catch
                {
                    outputResult = false;
                }
            }
            return outputResult;
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}