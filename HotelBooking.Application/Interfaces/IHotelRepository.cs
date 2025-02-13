using HotelBooking.Domain.Entities;
namespace HotelBooking.Application.Interfaces;

public interface IHotelRepository
{
    Task<IEnumerable<Hotel>> GetAllAsync();
    Task<Hotel?> GetByIdAsync(int id);
    Task AddAsync(Hotel hotel);
    Task UpdateAsync(Hotel hotel);
    Task DeleteAsync(int id);
}