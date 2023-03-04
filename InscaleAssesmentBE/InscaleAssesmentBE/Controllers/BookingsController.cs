using BusinessLayer.Services;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace InscaleAssesmentBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingsService _bookingsService;

        public BookingsController(IBookingsService bookingsService)
        {
            _bookingsService = bookingsService;
        }

        [HttpPost]
        public async Task<ActionResult<Booking>> BookResource(Booking booking) 
        {
            return await _bookingsService.InsertBooking(booking);
        }
    }
}
