using HotelBooking.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBooking.Application.Interfaces
{
    public interface IReservationRepository
    {
        Task<Reservation> AddReservationAsync(Reservation reservation);
        Task<IEnumerable<Reservation>> GetReservationsAsync();
        Task<Reservation?> GetReservationByIdAsync(int reservationId);
        Task<IEnumerable<Reservation>> GetReservationsByGuestAsync(int guestId);
        Task<IEnumerable<Reservation>> GetReservationsByHotelAsync(int hotelId);
        Task<bool> UpdateReservationAsync(Reservation reservation);
        Task<bool> DeleteReservationAsync(int reservationId);
    }
}
