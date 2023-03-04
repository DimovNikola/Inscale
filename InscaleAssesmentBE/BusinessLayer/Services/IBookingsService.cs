using BusinessLayer.Response;
using DataAccessLayer.DTOs;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface IBookingsService
    {
        Task<List<BookingDTO>> GetBookings();
        Task<Response<BookingDTO>> InsertBooking(Booking booking);
    }
}
