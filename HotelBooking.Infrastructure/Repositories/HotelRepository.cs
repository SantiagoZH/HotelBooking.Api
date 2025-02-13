using HotelBooking.Application.Interfaces;
using HotelBooking.Domain.Entities;
using HotelBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Infrastructure.Repositories;

public class HotelRepository : IHotelRepository
{
    private readonly HotelBookingDbContext _context;

    public HotelRepository(HotelBookingDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Hotel>> GetAllAsync()
    {
        return await _context.Hotels.ToListAsync();
    }

    public async Task<Hotel?> GetByIdAsync(int id)
    {
        return await _context.Hotels.FindAsync(id);
    }

    public async Task AddAsync(Hotel hotel)
    {
        _context.Hotels.Add(hotel);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Hotel hotel)
    {
        _context.Hotels.Update(hotel);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var hotel = await _context.Hotels.FindAsync(id);
        if (hotel != null)
        {
            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();
        }
    }
}
