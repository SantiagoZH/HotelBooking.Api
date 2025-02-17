using HotelBooking.Application.Interfaces;
using HotelBooking.Domain.Entities;
using HotelBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBooking.Infrastructure.Repositories;

public class HotelRepository : IHotelRepository
{
    private readonly HotelBookingDbContext _context;
    public HotelRepository(HotelBookingDbContext context)
    {
        _context = context;
        
    }
    public async Task<IEnumerable<Hotel>> GetAllAsync() => await Task.FromResult(_context.Hotels);

    public async Task<Hotel?> GetByIdAsync(int id) =>
        await Task.FromResult(_context.Hotels.FirstOrDefault(h => h.Id == id));

    public async Task AddAsync(Hotel hotel)
    {
        try
        {
            _context.Hotels.Add(hotel);
            await Task.CompletedTask;
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
       
    }

    public async Task<bool> UpdateHotelAsync(Hotel hotel)
    {
        var existingHotel = _context.Hotels.FirstOrDefault(h => h.Id == hotel.Id);
        if (existingHotel != null)
        {
            existingHotel.Name = hotel.Name;
            existingHotel.Address = hotel.Address;
            existingHotel.City = hotel.City;
            existingHotel.CommissionRate = hotel.CommissionRate;
            existingHotel.IsActive = hotel.IsActive;
        }
        return await _context.SaveChangesAsync() > 0;

        //await Task.CompletedTask;
    }

    public async Task DeleteAsync(int id)
    {
        var hotel = _context.Hotels.FirstOrDefault(h => h.Id == id);
        if (hotel != null)
            _context.Hotels.Remove(hotel);
        await _context.SaveChangesAsync();

        await Task.CompletedTask;
    }
    public async Task<IEnumerable<Hotel>> GetHotelsByCityAsync(string city)
    {
        return await _context.Hotels.Where(h => h.City == city && h.IsActive).ToListAsync();
    }
    public async Task<Hotel?> GetHotelByIdAsync(int id)
    {
        return await _context.Hotels.FindAsync(id);
    }

    public async Task<bool> ToggleHotelStatusAsync(int id)
    {
        var hotel = await _context.Hotels.FindAsync(id);
        if (hotel == null) return false;

        hotel.ToggleActiveStatus();
        await _context.SaveChangesAsync();
        return true;
    }
  
}
