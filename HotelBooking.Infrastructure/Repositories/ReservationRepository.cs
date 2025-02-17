using HotelBooking.Application.Interfaces;
using HotelBooking.Domain.Entities;
using HotelBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBooking.Infrastructure.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly HotelBookingDbContext _context;

        public ReservationRepository(HotelBookingDbContext context)
        {
            _context = context;
        }

        public async Task<Reservation?> GetByIdAsync(int id)
        {
            return await _context.Reservations
                .Include(r => r.Hotel)
                .Include(r => r.Room)
                .Include(r => r.Guests) 
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Reservation>> GetAllAsync()
        {
            return await _context.Reservations
                .Include(r => r.Hotel)
                .Include(r => r.Room)
                .Include(r => r.Guests) 
                .ToListAsync();
        }

        public async Task<IEnumerable<Reservation>> GetReservationsByHotelAsync(int hotelId)
        {
            return await _context.Reservations
                .Where(r => r.HotelId == hotelId)
                .Include(r => r.Guests) 
                .ToListAsync();
        }

        public async Task<IEnumerable<Reservation>> GetReservationsByGuestAsync(int guestId)
        {
            return await _context.Reservations
                .Where(r => r.Guests.Any(g => g.Id == guestId)) 
                .Include(r => r.Hotel)
                .Include(r => r.Room)
                .Include(r => r.Guests) 
                .ToListAsync();
        }

        public async Task AddAsync(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
                await _context.SaveChangesAsync();
            }
        }
    }
}
