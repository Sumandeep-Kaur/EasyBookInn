using HotelRoomBookingApp.DAL.Entities;
using HotelRoomBookingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelRoomBookingApp.Helper
{
    public class UserLogintoUserHelper
    {
        public User UserLogintoUserMapping(UserLogin e)
        {
            User u = new User();
            u.EmailId = e.EmailId;
            u.Password = e.Password;
            return u;
        }
    }
}
