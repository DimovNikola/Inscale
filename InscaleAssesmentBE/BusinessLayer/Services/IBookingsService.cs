namespace BusinessLayer.Services
{
    using BusinessLayer.Response;
    using DataAccessLayer.DTOs;
    using DataAccessLayer.Models;
    using System.Threading.Tasks;

    public interface IBookingsService
    {
        Task<Response<BookingDTO>> InsertBooking(Booking booking);
    }
}
