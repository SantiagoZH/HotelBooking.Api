using HotelBooking.Application.Services;
using HotelBooking.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly GuestService _guestService;

        public GuestController(GuestService guestService)
        {
            _guestService = guestService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGuest([FromBody] Guest guest)
        {
            var newGuest = await _guestService.CreateGuestAsync(guest);
            return CreatedAtAction(nameof(GetGuestById), new { guestId = newGuest.Id }, newGuest);
        }

        [HttpGet("reservation/{reservationId}")]
        public async Task<IActionResult> GetGuestsByReservation(int reservationId)
        {
            var guests = await _guestService.GetGuestsByReservationAsync(reservationId);
            return Ok(guests);
        }

        [HttpGet("{guestId}")]
        public async Task<IActionResult> GetGuestById(int guestId)
        {
            var guest = await _guestService.GetGuestByIdAsync(guestId);
            if (guest == null) return NotFound();
            return Ok(guest);
        }

        [HttpPut("{guestId}")]
        public async Task<IActionResult> UpdateGuest(int guestId, [FromBody] Guest guest)
        {
            guest.Id = guestId;
            var result = await _guestService.UpdateGuestAsync(guest);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("{guestId}")]
        public async Task<IActionResult> DeleteGuest(int guestId)
        {
            var result = await _guestService.DeleteGuestAsync(guestId);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
