using AutoBogus;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using WebTest.Controllers;
using WebTest.Entities;
using WebTest.Models;
using WebTest.Persistence;

namespace WebTest.Tests.Services
{
    public class DeleteClientControllerTests
    {
        [Fact]
        public void DeleteClient_ReturnsOKResult()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<APIDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemory_Test_Database")
                .Options;

            var id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f11af99");

            var context = new APIDbContext(options);

            context.Clients.AddRange(new AutoFaker<Client>()
            .RuleFor(o => o.ClientID, id)
            .Generate());

            context.SaveChanges();

            var mockMapper = new Mock<IMapper>();

            var controller = new ClientController(context, mockMapper.Object);

            // Act
            var result = controller.DeleteClient(id);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(result);
        }

        [Fact]
        public void DeleteClient_ReturnNotFoundResult()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<APIDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemory_Test_Database")
                .Options;

            var id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f11af99");

            var context = new APIDbContext(options);

            var postClient = new AutoFaker<Client>()
            .RuleFor(o => o.ClientID, id)
            .Generate();

            context.SaveChanges();

            var mockMapper = new Mock<IMapper>();

            var controller = new ClientController(context, mockMapper.Object);

            // Act
            var result = controller.DeleteClient(id);

            // Assert
            Assert.IsType<NotFoundResult>(result);
            Assert.NotNull(result);
        }

    }
}
