using AutoMapper;
using DataAccessLayer.DTOs;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.AutoMapperProfiles
{
    public class ResourceProfile : Profile
    {
        public ResourceProfile()
        {
            CreateMap<ResourceDTO, Resource>().ReverseMap();
        }
    }
}
