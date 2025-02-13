using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Domain.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public int HotelId { get; set; }

        [Required]
        public string Type { get; set; } 

        [Required]
        public decimal BasePrice { get; set; }

        public decimal Taxes { get; set; }
        public bool IsAvailable { get; set; } = true;

        public string Location { get; set; } 

        public Hotel Hotel { get; set; }
    }
}
