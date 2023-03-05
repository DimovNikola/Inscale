namespace BusinessLayer.Helpers
{
    using BusinessLayer.Common;
    using BusinessLayer.Response;
    using DataAccessLayer.DTOs;
    using DataAccessLayer.Models;
    using DataAccessLayer.Repository;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class BookingsHelpers : IBookingsHelpers
    {
        private readonly IRepository<Booking> _repository;
        private readonly IDateManager _dateManager;

        public BookingsHelpers(IRepository<Booking> repository, IDateManager dateManager)
        {
            _repository = repository;
            _dateManager = dateManager;
        }

        public async Task<Dictionary<int, List<Booking>>> GetBookingsForResource(int resourceId, Booking booking)
        {
            var bookings = await _repository.GetAll();

            if (bookings == null)
            {
                return new Dictionary<int, List<Booking>>();
            }

            var conflictingBookings = bookings
                .Where(b =>
                    _dateManager.CheckDateConflictingInterval(
                        b.DateFrom,
                        b.DateTo,
                        booking.DateFrom,
                        booking.DateTo
                    ) && b.ResourceId == resourceId
                ).ToList();

            return conflictingBookings.Count != 0
                ? new Dictionary<int, List<Booking>>() {
                    {
                        conflictingBookings.Sum(b => b.BookedQuantity), bookings
                    }
                }
                : new Dictionary<int, List<Booking>>();
        }

        public Response<BookingDTO> CheckCanBookResource(int totalAfterBooking, Response<BookingDTO> response, Resource? resource)
        {
            if (resource == null)
            {
                response.Message = "Resource Not Found!";
                response.Data = null;

                return response;
            }

            var exceededQuantity = ResourceQuantityExceeded(resource.Quantity, totalAfterBooking);
            if (exceededQuantity)
            {
                response.Message = "Resource Quantity Exceeded for Given Dates!";
                response.Data = null;

                return response;
            }

            return response;
        } 

        public bool ResourceQuantityExceeded(int resourceQuantity, int totalAfterBooking) => resourceQuantity < totalAfterBooking;
    }
}
