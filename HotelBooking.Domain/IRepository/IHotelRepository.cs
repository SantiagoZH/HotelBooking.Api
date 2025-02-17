using HotelBooking.Domain.Entities;

namespace HotelBooking.Application.Interfaces;

public interface IHotelRepository
{
    Task<IEnumerable<Hotel>> GetAllAsync();
    Task<Hotel?> GetByIdAsync(int id);
    Task<bool> ToggleHotelStatusAsync(int id);
    Task<bool> UpdateHotelAsync(Hotel hotel);
    Task AddAsync(Hotel hotel);
    Task DeleteAsync(int id);
    Task<IEnumerable<Hotel>> GetHotelsByCityAsync(string city);
}
