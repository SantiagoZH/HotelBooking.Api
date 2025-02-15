using HotelBooking.Domain.Entities;

namespace HotelBooking.Application.Interfaces;

public interface IHotelService
{
    Task<IEnumerable<Hotel>> GetAllHotelsAsync();
    Task<Hotel?> GetHotelByIdAsync(int id);
    Task<Hotel> AddHotelAsync(string name, string address, string city, decimal commissionRate);
    Task<bool> ToggleHotelStatusAsync(int id);

}
