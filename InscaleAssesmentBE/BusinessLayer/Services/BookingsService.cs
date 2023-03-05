namespace BusinessLayer.Services
{
    using AutoMapper;
    using BusinessLayer.Helpers;
    using BusinessLayer.Response;
    using DataAccessLayer.Data;
    using DataAccessLayer.DTOs;
    using DataAccessLayer.Models;
    using DataAccessLayer.Repository;
    using MailingServiceMock.EmailManager;

    public class BookingsService : BaseService<Booking>, IBookingsService
    {
        private DataContext _context;
        private readonly IMapper _mapper;
        private readonly IMailingManager _mailingManager;
        private readonly IBookingsHelpers _bookingsHelpers;

        public BookingsService( 
            IRepository<Booking> repository, 
            DataContext context,
            IMapper mapper, 
            IMailingManager mailingManager, 
            IBookingsHelpers bookingsHelpers) : base(repository)
        {
            _context = context;
            _mapper = mapper;
            _mailingManager = mailingManager;
            _bookingsHelpers = bookingsHelpers;
        }

        public async Task<Response<BookingDTO>> InsertBooking(Booking booking)
        {
            var bookings = await _bookingsHelpers.GetBookingsForResource(booking.ResourceId, booking);
            var totalBooked = bookings.FirstOrDefault().Key;
            var response = new Response<BookingDTO>();

            if (totalBooked != 0)
            {
                var totalAfterBooking = booking.BookedQuantity + totalBooked;
                var resource = _context.Resources.FirstOrDefault(resource => resource.Id == booking.ResourceId);

                var canBookResourceResponse = _bookingsHelpers.CheckCanBookResource(totalAfterBooking, response, resource);

                if(!String.IsNullOrEmpty(canBookResourceResponse.Message))
                {
                    return canBookResourceResponse;
                }
            }

            var savedBooking = await _repository.Insert(booking);
            var bookingDto = _mapper.Map<BookingDTO>(savedBooking);

            response.Message = "Resource Booked Successfully!";
            response.Data = bookingDto;

            _repository.Save();

            _mailingManager.SendEmailBookedResource(savedBooking.Id);

            return response;
        }
    }
}
