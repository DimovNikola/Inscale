using AutoMapper;
using BusinessLayer.Response;
using DataAccessLayer.DTOs;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class ResourcesService : BaseService<ResourceDto>, IResourcesService
    {
        private readonly IMapper _mapper;

        public ResourcesService(IRepository<ResourceDto> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public async Task<Response<List<ResourceDTO>>> GetResources() 
        {
            var response = new Response<List<ResourceDTO>>();
            var resources = await _repository.GetAll();
            
            if(resources.Count == 0)
            {
                response.Message = "No Available Resources!";
                response.Data = null;

                return response;
            }

            var resourcesDtos = resources.Select(booking => _mapper.Map<ResourceDTO>(booking)).ToList();
            response.Message = "Retrieved Resource List";
            response.Data = resourcesDtos;
            
            return response;
        } 
    }
}
