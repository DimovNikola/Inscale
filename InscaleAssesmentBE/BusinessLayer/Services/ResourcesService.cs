namespace BusinessLayer.Services
{
    using AutoMapper;
    using BusinessLayer.Response;
    using DataAccessLayer.DTOs;
    using DataAccessLayer.Models;
    using DataAccessLayer.Repository;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ResourcesService : BaseService<Resource>, IResourcesService
    {
        private readonly IMapper _mapper;

        public ResourcesService(IRepository<Resource> repository, IMapper mapper) : base(repository)
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
