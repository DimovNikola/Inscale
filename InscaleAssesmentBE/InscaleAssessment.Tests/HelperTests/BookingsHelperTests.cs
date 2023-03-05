namespace InscaleAssessment.Tests.HelperTests
{
    using BusinessLayer.Common;
    using BusinessLayer.Helpers;
    using BusinessLayer.Response;
    using DataAccessLayer.DTOs;
    using DataAccessLayer.Models;
    using DataAccessLayer.Repository;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;

    public class BookingsHelperTests
    {
        List<Booking> bookings = new List<Booking>()
        {
            new Booking()
            {
                Id = 0,
                DateFrom = It.IsAny<DateTime>(),
                DateTo = It.IsAny<DateTime>(),
                BookedQuantity = 10,
                ResourceId = 1
            },
            new Booking()
            {
                Id = 0,
                DateFrom = It.IsAny<DateTime>(),
                DateTo = It.IsAny<DateTime>(),
                BookedQuantity = 10,
                ResourceId = 1
            }
        };

        Resource resource = new Resource()
        {
            Id = 0,
            Name = "Resource X",
            Quantity = 100
        };

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

        private readonly Mock<IRepository<Booking>> _repository;
        private readonly Mock<IDateManager> _dateManager;

        public BookingsHelperTests()
        {
            _repository = new Mock<IRepository<Booking>>();
            _dateManager = new Mock<IDateManager>();
        }

        [Fact]
        public async void GetBookings_GetBookingsForResourceHasConflictingBookings_ReturnsDictOfConflictingBookings()
        {
            // Arrange
            var bookingsHelpers = new BookingsHelpers(_repository.Object, _dateManager.Object);

            _repository.Setup(x => x.GetAll())
                .Returns(Task.FromResult(bookings));
  
            _dateManager.Setup(x => x.CheckDateConflictingInterval(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .Returns(true);
            
                // Act
            var result = await bookingsHelpers.GetBookingsForResource(1, booking);

            // Assert
            Assert.IsType<Dictionary<int, List<Booking>>>(result);
            Assert.Equal(20, result.FirstOrDefault().Key);
            Assert.Single(result.Values);
            Assert.Single(result.Keys);
        }

        [Fact]
        public async void GetBookings_GetBookingsForResourceNoConflictingBookings_ReturnsEmptyDict()
        {
            // Arrange
            var bookingsHelpers = new BookingsHelpers(_repository.Object, _dateManager.Object);

            _repository.Setup(x => x.GetAll())
                .Returns(Task.FromResult(bookings));

            _dateManager.Setup(x => x.CheckDateConflictingInterval(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .Returns(false);

            // Act
            var result = await bookingsHelpers.GetBookingsForResource(1, booking);

            // Assert
            Assert.IsType<Dictionary<int, List<Booking>>>(result);
            Assert.Equal(0, result.FirstOrDefault().Key);
            Assert.Empty(result.Values);
            Assert.Empty(result.Keys);
        }

        [Fact]
        public void BookResource_CheckCanBookResource_CanBookResource()
        {
            // Arrange
            var response = new Response<BookingDTO>();
            var bookingsHelpers = new BookingsHelpers(_repository.Object, _dateManager.Object);

            // Act
            var canBookResource = bookingsHelpers.CheckCanBookResource(20, response, resource);

            // Assert
            Assert.Null(canBookResource.Message);
            Assert.Null(canBookResource.Data);
        }

        [Fact]
        public void BookResource_CheckCanBookResourceResourceQuantityExceeded_CannotBookResource()
        {
            // Arrange
            var response = new Response<BookingDTO>();
            var bookingsHelpers = new BookingsHelpers(_repository.Object, _dateManager.Object);
            var message = "Resource Quantity Exceeded for Given Dates!";

            // Act
            var canBookResource = bookingsHelpers.CheckCanBookResource(120, response, resource);

            // Assert
            Assert.Equal(message, canBookResource.Message);
            Assert.Null(canBookResource.Data);
        }

        [Fact]
        public void BookResource_CheckCanBookResourceResourceNotFound_CannotBookResource()
        {
            // Arrange
            var response = new Response<BookingDTO>();
            var bookingsHelpers = new BookingsHelpers(_repository.Object, _dateManager.Object);
            var message = "Resource Not Found!";

            // Act
            var canBookResource = bookingsHelpers.CheckCanBookResource(20, response, null);

            // Assert
            Assert.Equal(message, canBookResource.Message);
            Assert.Null(canBookResource.Data);
        }

        [Fact]
        public void Resources_ResourceQuantityExceeded_ReturnTrue()
        {
            // Arrange
            var bookingsHelpers = new BookingsHelpers(_repository.Object, _dateManager.Object);

            // Act
            var exceeded = bookingsHelpers.ResourceQuantityExceeded(100, 200);

            //Assert
            Assert.True(exceeded);
        }

        [Fact]
        public void Resources_ResourceQuantityNotExceeded_ReturnFalse()
        {
            // Arrange
            var bookingsHelpers = new BookingsHelpers(_repository.Object, _dateManager.Object);

            // Act
            var exceeded = bookingsHelpers.ResourceQuantityExceeded(100, 50);

            //Assert
            Assert.False(exceeded);
        }
    }
}
