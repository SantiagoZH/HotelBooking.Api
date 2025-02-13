using HotelBooking.Application.Interfaces;
using HotelBooking.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBooking.Application.Services
{
    public class ReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<Reservation> CreateReservationAsync(Reservation reservation)
        {
            return await _reservationRepository.AddReservationAsync(reservation);
        }

        public async Task<IEnumerable<Reservation>> GetAllReservationsAsync()
        {
            return await _reservationRepository.GetReservationsAsync();
        }

        public async Task<Reservation?> GetReservationByIdAsync(int reservationId)
        {
            return await _reservationRepository.GetReservationByIdAsync(reservationId);
        }

        public async Task<IEnumerable<Reservation>> GetReservationsByGuestAsync(int guestId)
        {
            return await _reservationRepository.GetReservationsByGuestAsync(guestId);
        }

        public async Task<IEnumerable<Reservation>> GetReservationsByHotelAsync(int hotelId)
        {
            return await _reservationRepository.GetReservationsByHotelAsync(hotelId);
        }

        public async Task<bool> UpdateReservationAsync(Reservation reservation)
        {
            return await _reservationRepository.UpdateReservationAsync(reservation);
        }

        public async Task<bool> DeleteReservationAsync(int reservationId)
        {
            return await _reservationRepository.DeleteReservationAsync(reservationId);
        }
    }
}
