using HotelBooking.Application.Interfaces;
using HotelBooking.Domain.Entities;
using HotelBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public async Task<Reservation> AddReservationAsync(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
            return reservation;
        }

        public async Task<IEnumerable<Reservation>> GetReservationsAsync()
        {
            return await _context.Reservations.Include(r => r.Hotel)
                                              .Include(r => r.Room)
                                              .Include(r => r.Guest)
                                              .ToListAsync();
        }

        public async Task<Reservation?> GetReservationByIdAsync(int reservationId)
        {
            return await _context.Reservations.Include(r => r.Hotel)
                                              .Include(r => r.Room)
                                              .Include(r => r.Guest)
                                              .FirstOrDefaultAsync(r => r.Id == reservationId);
        }

        public async Task<IEnumerable<Reservation>> GetReservationsByGuestAsync(int guestId)
        {
            return await _context.Reservations.Where(r => r.GuestId == guestId).ToListAsync();
        }

        public async Task<IEnumerable<Reservation>> GetReservationsByHotelAsync(int hotelId)
        {
            return await _context.Reservations.Where(r => r.HotelId == hotelId).ToListAsync();
        }

        public async Task<bool> UpdateReservationAsync(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteReservationAsync(int reservationId)
        {
            var reservation = await _context.Reservations.FindAsync(reservationId);
            if (reservation == null) return false;
            _context.Reservations.Remove(reservation);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
