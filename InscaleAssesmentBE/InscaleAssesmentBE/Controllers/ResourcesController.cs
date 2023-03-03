using BusinessLayer.Services;
using DataAccessLayer.DTOs;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace InscaleAssesmentBE.Controllers
{
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
        public async Task<ActionResult<List<Resource>>> GetAllResources()
        {
            return await _resourcesService.GetResources();
        }
    }
}
