using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class ResourcesService : BaseService<Resource>, IResourcesService
    {
        public ResourcesService(IRepository<Resource> repository) : base(repository)
        {

        }

        public Task<List<Resource>> GetResources() => _repository.GetAll();
    }
}
