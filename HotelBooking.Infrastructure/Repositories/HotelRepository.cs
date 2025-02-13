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
    private readonly List<Hotel> _hotels = new(); // Simulación de base de datos en memoria
    public HotelRepository(HotelBookingDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Hotel>> GetAllAsync() => await Task.FromResult(_hotels);

    public async Task<Hotel?> GetByIdAsync(int id) =>
        await Task.FromResult(_hotels.FirstOrDefault(h => h.Id == id));

    public async Task AddAsync(Hotel hotel)
    {
        hotel.Id = _hotels.Count + 1;
        _hotels.Add(hotel);
        await Task.CompletedTask;
    }

    public async Task UpdateAsync(Hotel hotel)
    {
        var existingHotel = _hotels.FirstOrDefault(h => h.Id == hotel.Id);
        if (existingHotel != null)
        {
            existingHotel.Name = hotel.Name;
            existingHotel.Address = hotel.Address;
            existingHotel.City = hotel.City;
            existingHotel.CommissionRate = hotel.CommissionRate;
            existingHotel.IsActive = hotel.IsActive;
        }
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(int id)
    {
        var hotel = _hotels.FirstOrDefault(h => h.Id == id);
        if (hotel != null)
            _hotels.Remove(hotel);

        await Task.CompletedTask;
    }
    public async Task<IEnumerable<Hotel>> GetHotelsByCityAsync(string city)
    {
        return await  _context.Hotels
            .Where(h => h.City == city)
            .ToListAsync();
    }
}
