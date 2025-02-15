using HotelBooking.Application.Interfaces;
using HotelBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBooking.Application.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IGuestRepository _guestRepository;

        public ReservationService(IReservationRepository reservationRepository,
                                  IRoomRepository roomRepository,
                                  IGuestRepository guestRepository)
        {
            _reservationRepository = reservationRepository;
            _roomRepository = roomRepository;
            _guestRepository = guestRepository;
        }

        public async Task<IEnumerable<Reservation>> GetAllReservationsAsync()
        {
            return await _reservationRepository.GetAllAsync();
        }

        public async Task<Reservation?> GetReservationByIdAsync(int id)
        {
            return await _reservationRepository.GetByIdAsync(id);
        }

        public async Task<bool> CreateReservationAsync(Reservation reservation)
        {
            var room = await _roomRepository.GetRoomByIdAsync(reservation.RoomId);
            if (room == null || !room.IsAvailable)
            {
                throw new InvalidOperationException("Room is not available.");
            }

            var guest = await _guestRepository.GetGuestByIdAsync(reservation.GuestId);
            if (guest == null)
            {
                throw new InvalidOperationException("Guest not found.");
            }

            reservation.TotalPrice = CalculateTotalPrice(room.BasePrice, reservation.CheckInDate, reservation.CheckOutDate);
            reservation.Status = "Confirmed";

            await _reservationRepository.AddAsync(reservation);
            return true;
        }

        public async Task<bool> UpdateReservationAsync(Reservation reservation)
        {
            var existingReservation = await _reservationRepository.GetByIdAsync(reservation.Id);
            if (existingReservation == null)
            {
                return false;
            }

            existingReservation.CheckInDate = reservation.CheckInDate;
            existingReservation.CheckOutDate = reservation.CheckOutDate;
            existingReservation.Status = reservation.Status;

            await _reservationRepository.UpdateAsync(existingReservation);
            return true;
        }

        public async Task<bool> DeleteReservationAsync(int id)
        {
            var existingReservation = await _reservationRepository.GetByIdAsync(id);
            if (existingReservation == null)
            {
                return false;
            }

            await _reservationRepository.DeleteAsync(id);
            return true;
        }

        private decimal CalculateTotalPrice(decimal basePrice, DateTime checkIn, DateTime checkOut)
        {
            int nights = (checkOut - checkIn).Days;
            return basePrice * nights;
        }
    }
}
