using AutoMapper;
using BusinessLayer.Response;
using BusinessLayer.Services;
using DataAccessLayer.DTOs;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using Moq;
using Xunit;

namespace InscaleAssessment.Tests.ServicesTests
{
    public class ResourcesServiceTests
    {
        List<Resource> resources = new List<Resource>
        {
            new Resource {
                Id = 0,
                Name = "Resource X",
                Quantity = 100
            },
            new Resource
            {
                Id = 1,
                Name = "Resource Y",
                Quantity = 200
            }
        };

        List<ResourceDTO> resourcesDTOs = new List<ResourceDTO>
        {
            new ResourceDTO {
                Id = 0,
                Name = "Resource X",
                Quantity = 100
            },
            new ResourceDTO
            {
                Id = 1,
                Name = "Resource Y",
                Quantity = 200
            }
        };

        private readonly Mock<IRepository<Resource>> _repositoryMock;
        private readonly Mock<IMapper> _mapper;

        public ResourcesServiceTests()
        {
            _repositoryMock = new Mock<IRepository<Resource>>();
            _mapper = new Mock<IMapper>();
        }

        [Fact]
        public async void Resources_GetAllResources_ReturnsResources()
        {
            // Arrange
            var response = new Response<List<ResourceDTO>>();
            var resourcesService = new ResourcesService(_repositoryMock.Object, _mapper.Object);
            

            response.Message = "test message";
            response.Data = resourcesDTOs;

            _repositoryMock.Setup(x => x.GetAll())
                .Returns(Task.FromResult(resources));

            // Act
            var resourcesResponse = await resourcesService.GetResources();

            // Assert
            Assert.NotNull(resourcesResponse.Data);
            Assert.Equal(2, resourcesResponse.Data.Count);
            Assert.Equal(resourcesDTOs, response.Data);
        }

        [Fact]
        public async void Resources_GetAllResources_NoResourcesToReturn()
        {
            // Arrange
            var response = new Response<List<ResourceDTO>>();
            var resourcesService = new ResourcesService(_repositoryMock.Object, _mapper.Object);


            response.Message = "No Available Resources!";
            response.Data = null;

            _repositoryMock.Setup(x => x.GetAll())
                .Returns(Task.FromResult(new List<Resource>()));

            // Act
            var resourcesResponse = await resourcesService.GetResources();

            // Assert
            Assert.Equal(response.Data, resourcesResponse.Data);
            Assert.Equal(response.Message, resourcesResponse.Message);
        }
    }
}
