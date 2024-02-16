using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HotelRoomBookingApp.DAL.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }

    }


    public enum UserRole
    {
        User = 1,
        Admin = 2
    }
}
