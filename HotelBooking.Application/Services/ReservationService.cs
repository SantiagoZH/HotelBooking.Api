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

        public async Task<bool> CreateReservationAsync(int hotelId, int roomId, DateTime checkIn, DateTime checkOut, string nameContactEmergency, string phoneContactEmergency, string customerEmail, List<Guest> guests)
        {
            var room = await _roomRepository.GetRoomByIdAsync(roomId);
            if (room == null || !room.IsAvailable)
            {
                throw new InvalidOperationException("Room is not available.");
            }

            var reservation = new Reservation(hotelId, roomId, checkIn, checkOut, nameContactEmergency, phoneContactEmergency, 0);

         
            foreach (var guestDto in guests)
            {
                var guest = new Guest
                {
                    FirstName = guestDto.FirstName,
                    LastName = guestDto.LastName,
                    Gender = guestDto.Gender,
                    DocumentType = guestDto.DocumentType,
                    DocumentNumber = guestDto.DocumentNumber,
                    Email = guestDto.Email,
                    PhoneNumber = guestDto.PhoneNumber
                };

                await _guestRepository.AddGuestAsync(guest);
                reservation.Guests.Add(guest);
            }

            reservation.TotalPrice = room.BasePrice * (checkOut - checkIn).Days;
            await _reservationRepository.AddAsync(reservation);
            return true;

            //Email service disabled
            var reservationDetails = $"Hotel: {hotelId}\n" +
                             $"Room: {roomId}\n" +
                             $"Check-in: {checkIn}\n" +
                             $"Check-out: {checkOut}\n" +
                             $"Price: {reservation.TotalPrice}\n" +
                             $"Emergency Contact: {nameContactEmergency} ({phoneContactEmergency})";

            var emailService = new EmailService();
            await emailService.SendConfirmationEmailAsync(customerEmail, reservationDetails);

           
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

      
    }
}
