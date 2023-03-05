namespace InscaleAssesmentBE.Validations
{
    using DataAccessLayer.Models;
    using FluentValidation;

    public class BookingValidator : AbstractValidator<Booking>
    {
        public BookingValidator()
        {
            RuleFor(booking => booking.DateFrom.Date).NotEqual(new DateTime().Date).WithMessage("Date From Not Valid!");
            RuleFor(booking => booking.DateTo.Date).NotEqual(new DateTime().Date).WithMessage("Date To Not Valid!");
            RuleFor(booking => booking.BookedQuantity).GreaterThan(0).WithMessage("You Cannot Book Less Than 1 Resource Quantity!");
        }
    }
}
