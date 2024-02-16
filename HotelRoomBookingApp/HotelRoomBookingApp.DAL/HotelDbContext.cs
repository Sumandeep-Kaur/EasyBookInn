using HotelRoomBookingApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelRoomBookingApp.DAL
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options)
           : base(options)
        {

        }


        public DbSet<User> Users { get; set; }
       
    }
}
