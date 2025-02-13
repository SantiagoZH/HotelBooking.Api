using HotelBooking.Application.Services;
using HotelBooking.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly ReservationService _reservationService;

        public ReservationController(ReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation([FromBody] Reservation reservation)
        {
            var newReservation = await _reservationService.CreateReservationAsync(reservation);
            return CreatedAtAction(nameof(GetReservationById), new { reservationId = newReservation.Id }, newReservation);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReservations()
        {
            var reservations = await _reservationService.GetAllReservationsAsync();
            return Ok(reservations);
        }

        [HttpGet("{reservationId}")]
        public async Task<IActionResult> GetReservationById(int reservationId)
        {
            var reservation = await _reservationService.GetReservationByIdAsync(reservationId);
            if (reservation == null) return NotFound();
            return Ok(reservation);
        }

        [HttpGet("guest/{guestId}")]
        public async Task<IActionResult> GetReservationsByGuest(int guestId)
        {
            var reservations = await _reservationService.GetReservationsByGuestAsync(guestId);
            return Ok(reservations);
        }

        [HttpGet("hotel/{hotelId}")]
        public async Task<IActionResult> GetReservationsByHotel(int hotelId)
        {
            var reservations = await _reservationService.GetReservationsByHotelAsync(hotelId);
            return Ok(reservations);
        }

        [HttpPut("{reservationId}")]
        public async Task<IActionResult> UpdateReservation(int reservationId, [FromBody] Reservation reservation)
        {
            reservation.Id = reservationId;
            var result = await _reservationService.UpdateReservationAsync(reservation);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("{reservationId}")]
        public async Task<IActionResult> DeleteReservation(int reservationId)
        {
            var result = await _reservationService.DeleteReservationAsync(reservationId);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
