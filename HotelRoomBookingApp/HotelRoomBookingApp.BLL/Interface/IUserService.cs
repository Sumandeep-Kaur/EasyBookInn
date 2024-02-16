using HotelRoomBookingApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelRoomBookingApp.BLL.Interface
{
    public interface IUserService
    {
        public User UserExists(User user);
        public object GetUserById(int id);
    }
}
