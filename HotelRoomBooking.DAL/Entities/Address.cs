using System;
using System.ComponentModel.DataAnnotations;

namespace HotelRoomBooking.DAL.Entities
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }
}
