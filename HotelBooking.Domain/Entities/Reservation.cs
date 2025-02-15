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
        protected Reservation() { }

        // ✅ Constructor para crear una reserva válida
        public Reservation(int hotelId, int roomId, int guestId, DateTime checkIn, DateTime checkOut, decimal price)
        {
            if (checkIn >= checkOut)
                throw new ArgumentException("La fecha de check-in debe ser antes de la fecha de check-out.");

            if (price < 0)
                throw new ArgumentException("El precio total no puede ser negativo.");

            HotelId = hotelId;
            RoomId = roomId;
            GuestId = guestId;
            CheckInDate = checkIn;
            CheckOutDate = checkOut;
            TotalPrice = price;
            Status = "Pending";
        }

        // ✅ Regla de negocio: Calcular precio total
        public void CalculateTotalPrice(decimal basePrice, int nights, decimal taxes)
        {
            if (nights <= 0)
                throw new ArgumentException("El número de noches debe ser mayor a cero.");

            TotalPrice = (basePrice * nights) + taxes;
        }

        // ✅ Regla de negocio: Confirmar la reserva
        public void Confirm()
        {
            if (Status != "Pending")
                throw new InvalidOperationException("Solo se pueden confirmar reservas en estado 'Pending'.");

            Status = "Confirmed";
        }

        // ✅ Regla de negocio: Cancelar la reserva
        public void Cancel()
        {
            if (Status == "Cancelled")
                throw new InvalidOperationException("La reserva ya está cancelada.");

            Status = "Cancelled";
        }
    }
}
