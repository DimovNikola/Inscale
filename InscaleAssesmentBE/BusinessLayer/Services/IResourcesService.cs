using BusinessLayer.Response;
using DataAccessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface IResourcesService
    {
        Task<Response<List<ResourceDTO>>> GetResources();
    }
}
