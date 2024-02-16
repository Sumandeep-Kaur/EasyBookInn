using HotelRoomBookingApp.BLL.Interface;
using HotelRoomBookingApp.DAL.Entities;
using HotelRoomBookingApp.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelRoomBookingApp.BLL
{
    public class UserService : IUserService
    {
        private readonly IUserDAL _userDAL;

        public UserService(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }
        public User UserExists(User user)
        {
            var u = _userDAL.UserExists(user);
            if (u != null)
                return u;
            else
                return null;

        }

        public object GetUserById(int id)
        {
            var u = _userDAL.GetUserById(id);
            return u;


        }

    }
    
}

