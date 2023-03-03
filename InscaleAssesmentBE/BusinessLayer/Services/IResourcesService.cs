using DataAccessLayer.Models;
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
        Task<List<Resource>> GetResources();
    }
}
