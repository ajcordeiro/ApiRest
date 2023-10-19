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
    public class PutClientControllerTests
    {
        [Fact]
        public void PutClient_ReturnsOKResult()
        {
            //Arrange
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

            var updatedClient = new AutoFaker<ClientInputModel>()
             //.RuleFor(o => o.ClientID, id)
             .Generate();

            // Act
            var result = controller.PutClient(id, updatedClient);

            Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(result);
        }

        [Fact]
        public void PutClient_ReturnNotFoundResult()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<APIDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemory_Test_Database")
                .Options;

            var context = new APIDbContext(options);

            context.Clients.AddRange(new AutoFaker<Client>()
                .RuleFor(o => o.ClientID, Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f11af99"))
                .Generate());

            var mockMapper = new Mock<IMapper>();

            var controller = new ClientController(context, mockMapper.Object);

            var updatedClient = new AutoFaker<ClientInputModel>()
                .RuleFor(o => o.ClientID, Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f11af00"))
               .Generate();

            // Act
            var result = controller.PutClient(updatedClient.ClientID, updatedClient);

            Assert.IsType<NotFoundResult>(result);
            Assert.NotNull(result);
        }
    }
}
