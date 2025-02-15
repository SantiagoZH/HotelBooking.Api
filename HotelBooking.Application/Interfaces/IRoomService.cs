using HotelBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Interfaces
{
    public interface IRoomService
    {
        Task<Room> CreateRoomAsync(Room room);
        Task<IEnumerable<Room>> GetRoomsByHotelAsync(int hotelId);
        Task<Room?> GetRoomByIdAsync(int roomId);
        Task<bool> UpdateRoomAsync(Room room);
        Task<bool> DeleteRoomAsync(int roomId);
    }
}
