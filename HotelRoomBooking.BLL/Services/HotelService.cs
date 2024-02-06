using HotelRoomBooking.BLL.IServices;
using HotelRoomBooking.DAL.Entities;
using HotelRoomBooking.DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomBooking.BLL.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;
        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
        public async Task Add(Hotel hotel)
        {
            await _hotelRepository.Add(hotel);
            await _hotelRepository.SaveChangesAsync();
        }

        public async Task Update(Hotel hotel, int hotelId)
        {
            var currHotel = await _hotelRepository.GetHotelById(hotelId);
            currHotel.Name = hotel.Name;
            currHotel.Stars = hotel.Stars;
            currHotel.Phone = hotel.Phone;
            currHotel.NumberOfRooms = hotel.NumberOfRooms;
            currHotel.Address = hotel.Address;

            await _hotelRepository.Update(currHotel);
            await _hotelRepository.SaveChangesAsync();
        }

        public async Task Delete(int hotelId)
        {
            await _hotelRepository.Delete(hotelId);
            await _hotelRepository.SaveChangesAsync();
        }

        public async Task Delete(Hotel hotel)
        {
            await _hotelRepository.Delete(hotel);
            await _hotelRepository.SaveChangesAsync();
        }

        public async Task<List<Hotel>> GetAllHotels()
        {
            return await _hotelRepository.GetAllHotels();
        }

        public async Task<Hotel> GetHotelById(int hotelId)
        {
            return await _hotelRepository.GetHotelById(hotelId);
        }

        public async Task<List<Hotel>> GetHotelsByCity(string city)
        {
            return await _hotelRepository.GetHotelsByCity(city);
        }

        public async Task<List<Hotel>> GetHotelsByName(string hotelName)
        {
            return await _hotelRepository.GetHotelsByName(hotelName);
        }
    }
}
