using HotelRoomBookingApp.DAL.Entities;
using HotelRoomBookingApp.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelRoomBookingApp.DAL
{
    public class UserDAL : IUserDAL
    {
        private readonly HotelDbContext _context;

        public UserDAL(HotelDbContext dbContext)
        {
            _context = dbContext;
        }
        public User UserExists(User user)
        {
            var query = (_context.Users.FirstOrDefault(u => u.EmailId == user.EmailId && u.Password == user.Password));

            if (query != null)
            {
                User userDal = query;
                return userDal;
            }
            return null;

        }

        public object GetUserById(int id)
        {
            try
            {
                var user = _context.Users
                .Where(u => u.UserId == id)
                .Select(u => new
                {
                    u.UserId,
                    u.Name,
                    u.EmailId,
                })
                .FirstOrDefault();
                return user;

            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
    }
}
