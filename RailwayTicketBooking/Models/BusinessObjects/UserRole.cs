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
        public static byte GetRoleId(UserRoles userRole)
        {
            string userRoleStr = userRole.ToString();
            RW db = new RW();
            byte roleId = db.User_Role.Where(ur => ur.Name == userRoleStr).Select(ur => ur.Id).First();
            return roleId;
        }
    }
}