using HotelBooking.Application.Interfaces;
using HotelBooking.Application.Services;
using HotelBooking.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet("hotels")]
        public async Task<IActionResult> SearchHotels([FromQuery] string city, [FromQuery] DateTime checkIn, [FromQuery] DateTime checkOut, [FromQuery] int guests)
        {
            var hotels = await _searchService.SearchHotelsAsync(city, checkIn, checkOut, guests);
            return Ok(hotels);
        }
    }
}
