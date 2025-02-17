using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HotelBooking.Domain.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalPrice { get; set; } = 0;
        public string Status { get; set; } = "Pending";
        public string? NameContactEmergency { get; set; }
        public string? PhoneContactEmergency { get; set; }
        public List<Guest> Guests { get; set; } = new List<Guest>();

        public Hotel Hotel { get; set; } = null!;
        public Room Room { get; set; } = null!;

        public Reservation() { }
        public Reservation(int hotelId, int roomId, DateTime checkIn, DateTime checkOut, string nameContactEmergency, string phoneContactEmergency, decimal price)
        {
            if (checkIn >= checkOut)
                throw new ArgumentException("Check-in date must be before check-out date.");
            int night = (int)(checkOut - checkIn).TotalDays;
            price = CalculateTotalPrice(price, night, 19);
            if (price < 0)
                throw new ArgumentException("Total price cannot be negative.");

            HotelId = hotelId;
            RoomId = roomId;
            CheckInDate = checkIn;
            CheckOutDate = checkOut;
            NameContactEmergency = nameContactEmergency;
            PhoneContactEmergency = phoneContactEmergency;
            TotalPrice = price;
            Status = "Pending";
        }

        public decimal CalculateTotalPrice(decimal basePrice, int nights, decimal taxes)
        {
            if (nights <= 0)
                throw new ArgumentException("El número de noches debe ser mayor a cero.");

            return TotalPrice = ((basePrice * nights) * taxes / 100) + (basePrice * nights);
        }


        public void Confirm()
        {
            if (Status != "Pending")
                throw new InvalidOperationException("Solo se pueden confirmar reservas en estado 'Pending'.");

            Status = "Confirmed";
        }


        public void Cancel()
        {
            if (Status == "Cancelled")
                throw new InvalidOperationException("La reserva ya está cancelada.");

            Status = "Cancelled";
        }
    }
}