using AutoMapper;
using BusinessLayer.Common;
using BusinessLayer.Response;
using DataAccessLayer.Data;
using DataAccessLayer.DTOs;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class BookingsService : BaseService<Booking>, IBookingsService
    {
        private readonly IDateManager _dateManager;
        private DataContext _context;
        private readonly IMapper _mapper;

        public BookingsService(IDateManager dateManager, IRepository<Booking> repository, DataContext context, IMapper mapper) : base(repository)
        {
            _dateManager = dateManager;
            _context = context;
            _mapper = mapper;
        }

        // NOT USED FOR ASSESSMENT
        public async Task<List<BookingDTO>> GetBookings()
        {
            var result = await _repository.GetAll();
            
            return result.Select(booking => _mapper.Map<BookingDTO>(booking)).ToList();
        }

        public async Task<Response<BookingDTO>> InsertBooking(Booking booking)
        {
            var bookings = await GetBookingsForResource(booking.ResourceId, booking);
            var totalBooked = bookings.FirstOrDefault().Key;
            var response = new Response<BookingDTO>();

            if (totalBooked != 0)
            {
                var totalAfterBooking = booking.BookedQuantity + totalBooked;
                var resource = _context.Resources.SingleOrDefault(resource => resource.Id == booking.ResourceId);

                if(resource == null) 
                {
                    response.Message = "Resource Not Found!";
                    response.Data = null;

                    return response;
                }

                if (ResourceQuantityExceeded(resource.Quantity, totalAfterBooking))
                {
                    response.Message = "Resource Quantity Exceeded for Given Dates!";
                    response.Data = null;

                    return response;
                }
            } 

            var savedBooking = await _repository.Insert(booking);
            var bookingDto = _mapper.Map<BookingDTO>(savedBooking);

            response.Message = "Resource Booked Successfully!";
            response.Data = bookingDto;

            _repository.Save();

            return response;
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
