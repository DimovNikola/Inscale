﻿using BusinessLayer.Response;
using DataAccessLayer.DTOs;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Helpers
{
    public interface IBookingsHelpers
    {
        Task<Dictionary<int, List<Booking>>> GetBookingsForResource(int resourceId, Booking booking);
        Response<BookingDTO> CheckCanBookResource(int totalAfterBooking, Response<BookingDTO> response, Resource resource);
        bool ResourceQuantityExceeded(int resourceQuantity, int totalAfterBooking);
    }
}
