﻿using HotelBooking.Application.Interfaces;
using HotelBooking.Application.Services;
using HotelBooking.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Api.Controllers;

[ApiController]
[Route("api/hotels")]
public class HotelController : ControllerBase
{
    private readonly IHotelService _hotelService;

    public HotelController(IHotelService hotelService)
    {
        _hotelService = hotelService;
    }
    [Authorize]
    [HttpGet]

    public async Task<IActionResult> GetAll()
    {
        var hotels = await _hotelService.GetAllHotelsAsync();
        return Ok(hotels);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var hotel = await _hotelService.GetHotelByIdAsync(id);
        if (hotel == null) return NotFound();
        return Ok(hotel);
    }
    [HttpPut("{hotelId}")]
    [Authorize(Roles = "Agent")]
    public async Task<IActionResult> UpdateRoom(int hotelId, [FromBody] Hotel hotel)
    {
        hotel.Id = hotelId;
        var result = await _hotelService.UpdateHotelAsync(hotel);
        if (!result) return NotFound();
        return NoContent();
    }

    [HttpPost]
    [Authorize(Roles = "Agent")]
    public async Task<IActionResult> CreateHotel([FromBody] Hotel hotel)
    {
        var createdHotel = await _hotelService.AddHotelAsync(hotel.Name, hotel.Address, hotel.City, hotel.CommissionRate);
        return CreatedAtAction(nameof(GetById), new { id = createdHotel.Id }, createdHotel);
    }
    [HttpPatch("{id}/toggle-status")]
    [Authorize(Roles = "Agent")]
    public async Task<IActionResult> ToggleHotelStatus(int id)
    {
        var success = await _hotelService.ToggleHotelStatusAsync(id);
        if (!success) return NotFound();
        return NoContent();
    }
}