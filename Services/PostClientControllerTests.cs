using AutoBogus;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTest.Controllers;
using WebTest.Entities;
using WebTest.Models;
using WebTest.Persistence;

namespace WebTest.Tests.Services
{
    public class PostClientControllerTests
    {
        [Fact]
        public void PostClient_ReturnsOKResult()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<APIDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemory_Test_Database")
                .Options;

            var context = new APIDbContext(options);

            var postClient = new AutoFaker<Client>()
            .RuleFor(o => o.ClientID, new Guid())
            .Generate();

            var update = new AutoFaker<ClientInputModel>()
              .RuleFor(o => o.ClientID, new Guid())
              .Generate();

            context.Clients.AddRange(postClient);

            context.SaveChanges();

            var mockMapper = new Mock<IMapper>();

            var controller = new ClientController(context, mockMapper.Object);

            // Act
            var result = controller.PostClient(update);

            // Assert
            Assert.IsType<CreatedAtActionResult>(result);
             Assert.NotNull(result);
        }

        [Fact]
        public void PostClient_ReturnNotFoundResult()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<APIDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemory_Test_Database")
                .Options;

            var id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f11af99");

            var context = new APIDbContext(options);

            var postClient = new AutoFaker<ClientInputModel>()
                .Generate();

            context.ClientInputModels.AddRange(postClient);


            context.SaveChanges();

            var mockMapper = new Mock<IMapper>();

            var controller = new ClientController(context, mockMapper.Object);

            // Act
            var result = controller.PostClient(postClient);

            // Assert
            Assert.IsType<NotFoundResult>(result);
            Assert.NotNull(result);
        }

    }
}
