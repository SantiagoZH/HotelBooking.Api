using HotelBooking.Application.Interfaces;
using HotelBooking.Domain.Entities;

namespace HotelBooking.Application.Services
{
    public class SearchService : ISearchService
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IRoomRepository _roomRepository;

        public SearchService(IHotelRepository hotelRepository, IRoomRepository roomRepository)
        {
            _hotelRepository = hotelRepository;
            _roomRepository = roomRepository;
        }

        public async Task<IEnumerable<Hotel>> SearchHotelsAsync(string city, DateTime checkIn, DateTime checkOut, int guests)
        {
            // 1️⃣ Buscar hoteles en la ciudad
            var hotels = await _hotelRepository.GetHotelsByCityAsync(city);
            var availableHotels = new List<Hotel>();

            // 2️⃣ Verificar disponibilidad de habitaciones
            foreach (var hotel in hotels)
            {
                var availableRooms = await _roomRepository.GetAvailableRoomsByHotelAsync(hotel.Id, checkIn, checkOut, guests);
                if (availableRooms.Any())
                {
                    availableHotels.Add(hotel);
                }
            }

            return availableHotels;
        }
    }
}
