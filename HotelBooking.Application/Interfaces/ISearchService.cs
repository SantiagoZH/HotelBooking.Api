﻿using HotelBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Interfaces
{
    public interface ISearchService
    {
        Task<IEnumerable<Hotel>> SearchHotelsAsync(string city, DateTime checkIn, DateTime checkOut, int guests);
    }
}
