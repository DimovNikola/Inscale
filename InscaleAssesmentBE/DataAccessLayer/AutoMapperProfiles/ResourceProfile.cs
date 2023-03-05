namespace DataAccessLayer.AutoMapperProfiles
{
    using AutoMapper;
    using DataAccessLayer.DTOs;
    using DataAccessLayer.Models;

    public class ResourceProfile : Profile
    {
        public ResourceProfile()
        {
            CreateMap<ResourceDTO, Resource>().ReverseMap();
        }
    }
}
