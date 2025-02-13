using HotelBooking.Application.Interfaces;
using HotelBooking.Domain.Entities;
using HotelBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBooking.Infrastructure.Repositories
{
    public class GuestRepository : IGuestRepository
    {
        private readonly HotelBookingDbContext _context;

        public GuestRepository(HotelBookingDbContext context)
        {
            _context = context;
        }

        public async Task<Guest> AddGuestAsync(Guest guest)
        {
            _context.Guests.Add(guest);
            await _context.SaveChangesAsync();
            return guest;
        }

        public async Task<IEnumerable<Guest>> GetGuestsByReservationAsync(int reservationId)
        {
            return await _context.Guests.Where(g => g.Reservation.Id == reservationId).ToListAsync();
        }

        public async Task<Guest?> GetGuestByIdAsync(int guestId)
        {
            return await _context.Guests.FindAsync(guestId);
        }

        public async Task<bool> UpdateGuestAsync(Guest guest)
        {
            _context.Guests.Update(guest);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteGuestAsync(int guestId)
        {
            var guest = await _context.Guests.FindAsync(guestId);
            if (guest == null) return false;
            _context.Guests.Remove(guest);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
