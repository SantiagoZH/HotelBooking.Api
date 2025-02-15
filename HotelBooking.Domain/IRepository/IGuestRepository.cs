using HotelBooking.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBooking.Application.Interfaces
{
    public interface IGuestRepository
    {
        Task<Guest> AddGuestAsync(Guest guest);
        Task<IEnumerable<Guest>> GetGuestsByReservationAsync(int reservationId);
        Task<Guest?> GetGuestByIdAsync(int guestId);
        Task<bool> UpdateGuestAsync(Guest guest);
        Task<bool> DeleteGuestAsync(int guestId);
    }
}
