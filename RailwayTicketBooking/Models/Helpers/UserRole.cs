using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RailwayTicketBooking.Models
{

    public enum UserRoles
    {
        Admin,
        Moderator,
        User
    }

    public class UserRole
    {
        public static byte GetIdByName(string roleName)
        {
            RW rw = new RW();
            byte roleId = rw.UserRole.Where(ur => ur.Name == roleName).Select(ur => ur.Id).First();
            return roleId;
        }
    }
}