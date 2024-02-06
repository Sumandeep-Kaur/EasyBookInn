using HotelRoomBooking.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelRoomBooking.DAL.IRepository
{
    public interface IHotelRepository
    {
        Task Add(Hotel hotel);
        Task Update(Hotel hotel);
        Task Delete(int hotelId);
        Task Delete(Hotel hotel);
        Task<Hotel> GetHotelById(int hotelId);
        Task<List<Hotel>> GetAllHotels();
        Task<List<Hotel>> GetHotelsByName(string hotelName);
        Task<List<Hotel>> GetHotelsByCity(string city);
        Task SaveChangesAsync();
    }
}
