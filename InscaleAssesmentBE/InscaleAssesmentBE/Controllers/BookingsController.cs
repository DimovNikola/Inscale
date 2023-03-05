namespace InscaleAssesmentBE.Controllers
{
    using BusinessLayer.Services;
    using DataAccessLayer.Models;
    using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> BookResource(Booking booking) 
        {
            if(!ModelState.IsValid)
            {
                StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }

            return StatusCode(StatusCodes.Status201Created, await _bookingsService.InsertBooking(booking));
        }
    }
}
