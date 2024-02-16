using HotelRoomBookingApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelRoomBookingApp.DAL.Interface
{
    public interface IUserDAL
    {
        public User UserExists(User user);
        public object GetUserById(int id);


    }
}
