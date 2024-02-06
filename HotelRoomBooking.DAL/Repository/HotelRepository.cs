using HotelRoomBooking.DAL.Entities;
using HotelRoomBooking.DAL.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomBooking.DAL.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelBookingDbContext _dbContext = null;
        public HotelRepository(HotelBookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Hotel hotel)
        {
            await _dbContext.Hotels.AddAsync(hotel);
        }

        public Task Update(Hotel hotel)
        {
            _dbContext.Hotels.Update(hotel);
            return Task.CompletedTask;
        }

        public async Task Delete(int hotelId)
        {
            Hotel hotel = await _dbContext.Hotels.FindAsync(hotelId);
        }

        public Task Delete(Hotel hotel)
        {
            _dbContext.Hotels.Remove(hotel);
            return Task.CompletedTask;
        }

        public async Task<List<Hotel>> GetAllHotels()
        {
            return await _dbContext.Hotels.Include(h => h.Address).ToListAsync();
        }

        public async Task<Hotel> GetHotelById(int hotelId)
        {
            return await _dbContext.Hotels.FindAsync(hotelId);
        }

        public async Task<List<Hotel>> GetHotelsByName(string hotelName)
        {
            return await _dbContext.Hotels.Where(hotel => hotel.Name.Contains(hotelName)).ToListAsync();
        }

        public async Task<List<Hotel>> GetHotelsByCity(string city)
        {
            return await _dbContext.Hotels.Where(hotel => hotel.Address.City == city).ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
