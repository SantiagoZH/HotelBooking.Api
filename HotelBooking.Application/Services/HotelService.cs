using HotelBooking.Application.Interfaces;
using HotelBooking.Domain.Entities;

namespace HotelBooking.Application.Services;

public class HotelService : IHotelService
{
    private readonly IHotelRepository _hotelRepository;

    public HotelService(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
    }

    public async Task<IEnumerable<Hotel>> GetAllHotelsAsync() => await _hotelRepository.GetAllAsync();

    public async Task<Hotel?> GetHotelByIdAsync(int id) => await _hotelRepository.GetByIdAsync(id);

    public async Task<Hotel> AddHotelAsync(string name, string address, string city, decimal commissionRate)
    {
        var hotel = new Hotel(name, address, city, commissionRate);
        await _hotelRepository.AddAsync(hotel);
        return hotel;
    }
}
