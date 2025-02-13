using HotelBooking.Application.Services;
using HotelBooking.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly RoomService _roomService;

        public RoomController(RoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom([FromBody] Room room)
        {
            var newRoom = await _roomService.CreateRoomAsync(room);
            return CreatedAtAction(nameof(GetRoomById), new { roomId = newRoom.Id }, newRoom);
        }

        [HttpGet("hotel/{hotelId}")]
        public async Task<IActionResult> GetRoomsByHotel(int hotelId)
        {
            var rooms = await _roomService.GetRoomsByHotelAsync(hotelId);
            return Ok(rooms);
        }

        [HttpGet("{roomId}")]
        public async Task<IActionResult> GetRoomById(int roomId)
        {
            var room = await _roomService.GetRoomByIdAsync(roomId);
            if (room == null) return NotFound();
            return Ok(room);
        }

        [HttpPut("{roomId}")]
        public async Task<IActionResult> UpdateRoom(int roomId, [FromBody] Room room)
        {
            room.Id = roomId;
            var result = await _roomService.UpdateRoomAsync(room);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("{roomId}")]
        public async Task<IActionResult> DeleteRoom(int roomId)
        {
            var result = await _roomService.DeleteRoomAsync(roomId);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
