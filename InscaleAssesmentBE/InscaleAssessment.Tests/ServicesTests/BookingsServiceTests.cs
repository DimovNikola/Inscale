namespace InscaleAssessment.Tests.ServicesTests
{
    using BusinessLayer;
    using BusinessLayer.Common;
    using BusinessLayer.Helpers;
    using BusinessLayer.Response;
    using BusinessLayer.Services;
    using DataAccessLayer.AutoMapperProfiles;
    using DataAccessLayer.Data;
    using DataAccessLayer.DTOs;
    using DataAccessLayer.Models;
    using DataAccessLayer.Repository;
    using MailingServiceMock.EmailManager;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;
    using AutoMapper;

    public class BookingsServiceTests
    {
        Booking booking = new Booking
        {
            Id = 0,
            DateFrom = It.IsAny<DateTime>(),
            DateTo = It.IsAny<DateTime>(),
            BookedQuantity = 10,
            ResourceId = 1
        };

        BookingDTO bookingDTO = new BookingDTO
        {
            Id = 0,
            DateFrom = It.IsAny<DateTime>(),
            DateTo = It.IsAny<DateTime>(),
            BookedQuantity = 10,
        };

        Dictionary<int, List<Booking>> bookings = new Dictionary<int, List<Booking>>
        {
            { 1, new List<Booking>
                {
                    new Booking
                    {
                        Id = 0,
                        DateFrom = It.IsAny<DateTime>(),
                        DateTo = It.IsAny<DateTime>(),
                        BookedQuantity = 10,
                        ResourceId = 1
                    }
                }
            }
        };

        DbContextOptions<DataContext> options = new DbContextOptionsBuilder<DataContext>()
            .UseSqlite("Data Source=sqlite.db")
                .Options;

        private readonly Mock<IRepository<Booking>> _repositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IMailingManager> _mailingManagerMock;
        private readonly Mock<IBookingsHelpers> _bookingsHelpersMock;

        public BookingsServiceTests()
        {
            _repositoryMock = new Mock<IRepository<Booking>>();
            _mapperMock = new Mock<IMapper>();
            _mailingManagerMock = new Mock<IMailingManager>();
            _bookingsHelpersMock = new Mock<IBookingsHelpers>();
        }

        [Fact]
        public async void Booking_InsertBooking_ResourceBooked()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new BookingProfile());
            });
            var mapper = mockMapper.CreateMapper();

            // Arrange
            var dataContext = new DataContext(options);
            var response = new Response<BookingDTO>();
            var bookingsService = new BookingsService(_repositoryMock.Object, dataContext, mapper, _mailingManagerMock.Object, _bookingsHelpersMock.Object);
            var baseService = new BaseService<Booking>(_repositoryMock.Object);

            response.Message = "Resource Booked Successfully!";
            response.Data = bookingDTO;

            var emptyResp = new Response<BookingDTO>();

            _repositoryMock.Setup(x => x.Insert(booking))
                .Returns(Task.FromResult(booking));
            _bookingsHelpersMock.Setup(x => x.GetBookingsForResource(1, booking))
                .Returns(Task.FromResult(bookings));
            _bookingsHelpersMock.Setup(x => x.CheckCanBookResource(It.IsAny<int>(), It.IsAny<Response<BookingDTO>>(), It.IsAny<Resource>()))
                .Returns(emptyResp);

            // Act
            var bookingResponse = await bookingsService.InsertBooking(booking);

            // Assert
            Assert.NotNull(bookingResponse.Data);
            Assert.Equal(response.Message, bookingResponse.Message);
            Assert.Equal(response.Data.DateFrom, bookingResponse.Data.DateFrom);
            Assert.Equal(response.Data.DateTo, bookingResponse.Data.DateTo);
            Assert.Equal(response.Data.Id, bookingResponse.Data.Id);
            Assert.Equal(response.Data.BookedQuantity, bookingResponse.Data.BookedQuantity);
        }
    }
}
