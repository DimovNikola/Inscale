namespace BusinessLayer.Services
{
    using BusinessLayer.Response;
    using DataAccessLayer.DTOs;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IResourcesService
    {
        Task<Response<List<ResourceDTO>>> GetResources();
    }
}
