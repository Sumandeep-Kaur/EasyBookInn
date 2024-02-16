using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelRoomBookingApp.DAL.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace HotelRoomBookingApp.DAL
{
    class DataSeeder
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
          
            using (var seerviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = seerviceScope.ServiceProvider.GetService<HotelDbContext>();
                if (!context.Users.Any())
                {

                    var users = new List<User>
                    {

                        new User {Name="Shaoni", EmailId = "shaoni@gmail.com", PhoneNumber="123456789", Password = "P@ss", Role= UserRole.User},
                        new User {Name="Admin", EmailId = "admin@gmail.com", PhoneNumber="123456789", Password = "P@ss1", Role = UserRole.Admin}



                    };

                    context.Users.AddRange(users);
                    context.SaveChanges();
                }

            }
        }
    }
}
