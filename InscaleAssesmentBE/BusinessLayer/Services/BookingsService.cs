using BusinessLayer.Common;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class BookingsService : BaseService<Booking>, IBookingsService
    {
        private readonly IDateManager _dateManager;
        private DataContext _context;

        public BookingsService(IDateManager dateManager, IRepository<Booking> repository, DataContext context) : base(repository)
        {
            _dateManager = dateManager;
            _context = context;
        }

        public Task<List<Booking>> GetBookings() => _repository.GetAll();

        public async Task<Booking> InsertBooking(Booking booking)
        {
            var bookings = await GetBookingsForResource(booking.ResourceId, booking);
            var totalBooked = bookings.FirstOrDefault().Key;

            if (totalBooked != 0)
            {
                var resource = _context.Resources.SingleOrDefault(resource => resource.Id == booking.ResourceId);
                var totalAfterBooking = booking.BookedQuantity + totalBooked;

                if (ResourceQuantityExceeded(resource.Quantity, totalAfterBooking))
                {
                    return null;
                }
            } 

            var savedBooking = await _repository.Insert(booking);
            _repository.Save();

            return savedBooking;
        }
        
        private async Task<Dictionary<int, List<Booking>>> GetBookingsForResource(int resourceId, Booking booking)
        {
            var bookings = await _repository.GetAll();

            if(bookings == null)
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
                    )
                ).ToList();

            return conflictingBookings != null 
                ? new Dictionary<int, List<Booking>>() { 
                    { 
                        conflictingBookings.Sum(b => b.BookedQuantity), bookings 
                    } 
                } 
                : new Dictionary<int, List<Booking>>();
        }

        private bool ResourceQuantityExceeded(int resourceQuantity, int totalAfterBooking)
        {
            return resourceQuantity < totalAfterBooking;
        }
    }
}
