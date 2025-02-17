using HotelBooking.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBooking.Application.Interfaces
{
    public interface IRoomRepository
    {
        Task<Room> AddRoomAsync(Room room);
        Task<IEnumerable<Room>> GetRoomsByHotelAsync(int hotelId);
        Task<Room?> GetRoomByIdAsync(int roomId);
        Task<bool> UpdateRoomAsync(Room room);
        Task<bool> DeleteRoomAsync(int roomId);
        Task<IEnumerable<Room>> GetAvailableRoomsByHotelAsync(int hotelId, DateTime checkIn, DateTime checkOut, int guests);
    }
}
