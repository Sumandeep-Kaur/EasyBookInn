using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelRoomBooking.DAL.Entities
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stars { get; set; }
        public int NumberOfRooms { get; set; }
        public string Phone { get; set; }

        public int AddressID { get; set; }

        [ForeignKey("AddressID")]
        public Address Address { get; set; }
    }
}
