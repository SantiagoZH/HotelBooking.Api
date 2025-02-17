using HotelBooking.Application.Interfaces;
using HotelBooking.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBooking.Api.Controllers
{
    [ApiController]
    [Route("api/reservations")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetAllReservations()
        {
            return Ok(await _reservationService.GetAllReservationsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetReservation(int id)
        {
            var reservation = await _reservationService.GetReservationByIdAsync(id);
            if (reservation == null) return NotFound();
            return Ok(reservation);
        }
        [HttpPost]
        public async Task<IActionResult> CreateReservation([FromBody] CreateReservationRequest request)
        {
            var success = await _reservationService.CreateReservationAsync(
                request.HotelId,
                request.RoomId,
                request.CheckInDate,
                request.CheckOutDate,
                request.NameContactEmergency, 
                request.PhoneContactEmergency,
                request.customerEmail,
                request.Guests);

            if (!success) return BadRequest("Reservation could not be created.");
            return Ok("Reservation successfully created.");
        }

        public class CreateReservationRequest
        {
            public int HotelId { get; set; }
            public int RoomId { get; set; }
            public DateTime CheckInDate { get; set; }
            public DateTime CheckOutDate { get; set; }
            public string NameContactEmergency { get; set; }  
            public string PhoneContactEmergency { get; set; }  
            public string customerEmail { get; set; }
            public List<Guest> Guests { get; set; }
        }



        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateReservation(int id, [FromBody] Reservation reservation)
        {
            if (id != reservation.Id) return BadRequest("ID mismatch.");
            var success = await _reservationService.UpdateReservationAsync(reservation);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReservation(int id)
        {
            var success = await _reservationService.DeleteReservationAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }

}
