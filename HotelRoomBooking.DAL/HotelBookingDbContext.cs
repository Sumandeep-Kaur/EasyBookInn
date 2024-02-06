using HotelRoomBooking.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace HotelRoomBooking.DAL
{
    public class HotelBookingDbContext : DbContext
    {
        public HotelBookingDbContext(DbContextOptions<HotelBookingDbContext> options)
            : base(options)
        {

        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Hotel> Addresses { get; set; }
    }
}
