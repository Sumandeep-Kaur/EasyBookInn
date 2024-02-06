using HotelRoomBooking.BLL.IServices;
using HotelRoomBooking.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelRoomBooking.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHotels()
        {
            try
            {
                var hotels = await _hotelService.GetAllHotels();
                return Ok(hotels);
            }
            catch (Exception ex)
            {
                return NotFound(new
                {
                    ex.Message,
                    Error = "Cannot get data."
                });
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetHotel(int id)
        {
            try
            {
                var hotel = await _hotelService.GetHotelById(id);
                return Ok(hotel);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new
                {
                    ex.Message,
                    Error = "Key not found in database.",
                });
            }
        }

        [HttpGet("name")]
        public async Task<IActionResult> GetHotelByName(string name)
        {
            try
            {
                var hotel = await _hotelService.GetHotelsByName(name);
                return Ok(hotel);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new
                {
                    ex.Message,
                    Error = "Key not found in database.",
                });
            }
        }

        [HttpGet("city")]
        public async Task<IActionResult> GetHotelsByCity(string city)
        {
            try
            {
                var hotel = await _hotelService.GetHotelsByCity(city);
                return Ok(hotel);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new
                {
                    ex.Message,
                    Error = "Key not found in database.",
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddHote([FromBody] Hotel hotel)
        {
            try
            {
                await _hotelService.Add(hotel);
                return Ok(new
                {
                    Status = "Success",
                    Message = "Hotel Added Successfully!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    ex.Message,
                    Status = "Failed",
                    Messaage = "Cannot add hotel to database."
                });
            }
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateHotel(int id, [FromBody] Hotel hotel)
        {
            try
            {
                await _hotelService.Update(hotel, id);
                return Ok(new
                {
                    Status = "Success",
                    Message = "Hotel Updated Successfully!"
                });
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(new
                {
                    ex.Message,
                    Status = "Failed",
                    Messaage = "Cannot update hotel.",
                });
            }
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            try
            {
                await _hotelService.Delete(id);
                return Ok(new
                {
                    Status = "Success",
                    Message = "Hotel Deleted Successfully!"
                });
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(new
                {
                    ex.Message,
                    Status = "Failed",
                    Messaage = "Cannot delete hotel."
                });
            }
        }
    }
}
