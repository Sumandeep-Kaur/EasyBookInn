using HotelRoomBookingApp.DAL.Entities;
using HotelRoomBookingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelRoomBookingApp.Helper
{
    public class UserModeltoUserHelper
    {
        public User UserModeltoUserMapping(UserModel e)
        {
            User u = new User();
            u.Name = e.Name;
            u.EmailId = e.EmailId;
            u.Password = e.Password;
            u.PhoneNumber = e.PhoneNumber;
            u.Role = (DAL.Entities.UserRole)e.Role;
            return u;
        }
    }
}
