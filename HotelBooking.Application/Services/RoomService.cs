using HotelBooking.Application.Interfaces;
using HotelBooking.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBooking.Application.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<Room> CreateRoomAsync(Room room) => await _roomRepository.AddRoomAsync(room);

        public async Task<IEnumerable<Room>> GetRoomsByHotelAsync(int hotelId) => await _roomRepository.GetRoomsByHotelAsync(hotelId);

        public async Task<Room?> GetRoomByIdAsync(int roomId) => await _roomRepository.GetRoomByIdAsync(roomId);

        public async Task<bool> UpdateRoomAsync(Room room) => await _roomRepository.UpdateRoomAsync(room);

        public async Task<bool> DeleteRoomAsync(int roomId) => await _roomRepository.DeleteRoomAsync(roomId);
    }
}
