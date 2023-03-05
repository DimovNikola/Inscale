namespace DataAccessLayer.AutoMapperProfiles
{
    using AutoMapper;
    using DataAccessLayer.DTOs;
    using DataAccessLayer.Models;

    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<BookingDTO, Booking>().ReverseMap();
        }
    }
}
