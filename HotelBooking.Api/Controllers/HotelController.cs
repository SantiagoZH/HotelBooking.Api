
using HotelBooking.Application.Services;
using HotelBooking.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Api.Controllers;

[ApiController]
[Route("api/hotels")]
public class HotelController : ControllerBase
{
    private readonly HotelService _hotelService;

    public HotelController(HotelService hotelService)
    {
        _hotelService = hotelService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var hotels = await _hotelService.GetAllHotelsAsync();
        return Ok(hotels);
    }

    [HttpPost]
    public async Task<IActionResult> CreateHotel([FromBody] Hotel hotel)
    {
        await _hotelService.AddHotelAsync(hotel.Name, hotel.Address, hotel.City, hotel.CommissionRate);
        return CreatedAtAction(nameof(GetAll), new { id = hotel.Id }, hotel);
    }
}
