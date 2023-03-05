namespace InscaleAssesmentBE.Controllers
{
    using BusinessLayer.Response;
    using BusinessLayer.Services;
    using DataAccessLayer.DTOs;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class ResourcesController : ControllerBase
    {
        private readonly IResourcesService _resourcesService;

        public ResourcesController(IResourcesService resourcesService)
        {
            _resourcesService = resourcesService;
        }

        [HttpGet]
        public async Task<ActionResult<Response<List<ResourceDTO>>>> GetAllResources()
        {
            return await _resourcesService.GetResources();
        }
    }
}
