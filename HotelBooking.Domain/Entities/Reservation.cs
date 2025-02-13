using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int RoomId { get; set; }
        public int GuestId { get; set; }  // Relación con el huésped
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; } = "Pending"; // Estado de la reserva

        // Relaciones
        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
        public Guest Guest { get; set; }
    }
}
