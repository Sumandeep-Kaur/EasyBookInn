using HotelRoomBooking.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomBooking.BLL.IServices
{
    public interface IHotelService
    {
        Task Add(Hotel hotel);
        Task Update(Hotel hotel, int hotelId);
        Task Delete(int hotelId);
        Task Delete(Hotel hotel);
        Task<Hotel> GetHotelById(int hotelId);
        Task<List<Hotel>> GetAllHotels();
        Task<List<Hotel>> GetHotelsByName(string hotelName);
        Task<List<Hotel>> GetHotelsByCity(string city);
    }
}
