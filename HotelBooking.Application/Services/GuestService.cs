using HotelBooking.Application.Interfaces;
using HotelBooking.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBooking.Application.Services
{
    public class GuestService
    {
        private readonly IGuestRepository _guestRepository;

        public GuestService(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }

        public async Task<Guest> CreateGuestAsync(Guest guest) => await _guestRepository.AddGuestAsync(guest);

        public async Task<IEnumerable<Guest>> GetGuestsByReservationAsync(int reservationId) => await _guestRepository.GetGuestsByReservationAsync(reservationId);

        public async Task<Guest?> GetGuestByIdAsync(int guestId) => await _guestRepository.GetGuestByIdAsync(guestId);

        public async Task<bool> UpdateGuestAsync(Guest guest) => await _guestRepository.UpdateGuestAsync(guest);

        public async Task<bool> DeleteGuestAsync(int guestId) => await _guestRepository.DeleteGuestAsync(guestId);
    }
}
