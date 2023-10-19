using AutoBogus;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;
using WebTest.Controllers;
using WebTest.Entities;
using WebTest.Models;
using WebTest.Persistence;

namespace WebTest.Tests.Services
{
    public class GetClientControllerTests : BaseIntegrationTest
    {
        [Fact]
        public void GetAllClient_ReturnsOkResult()
        {
            // Arrange
            var clients = new List<Client>
            {
               new Client { ClientID = Guid.NewGuid(), Name = "Paulo", Address="Teste", Age = 44, DocumentNumber="125454545", IsActive = true }
            };
           // var mockContext = new Mock<IAPIDbContext>();

            MockSuccessGetGendersFromDb(mockContext);
            // mockContext.Setup(o => o.Clients);

            //var mockContext = new Mock<IAPIDbContext>();

            //DbSetExtensions.ReturnsDbSet(mockContext, clients); // Chama a extensão para configurar o DbSet simulado

            var mockMapper = new Mock<IMapper>();
            var controller = new ClientController(mockContext.Object, mockMapper.Object);


            // Act
            var result = controller.GetAllClient();

            // Assert
            Assert.IsType<OkObjectResult>(result);




           





            ////Arrange
            //var options = new DbContextOptionsBuilder<APIDbContext>()
            // .UseInMemoryDatabase(databaseName: "InMemory_Test_Database")
            // .Options;

            //var context = new APIDbContext(options);

            //context.Clients.AddRange(new AutoFaker<Client>()
            //    .Generate(3));

            //context.SaveChanges();

            //var mockMapper = new Mock<IMapper>();

            //var controller = new ClientController(context, mockMapper.Object);

            //// Act
            //var result = controller.GetAllClient();

            //// Assert

            //Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetClientActive_ReturnsOkResult()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<APIDbContext>()
             .UseInMemoryDatabase(databaseName: "InMemory_Test_Database")
             .Options;

            using (var context = new APIDbContext(options))
            {
                context.Clients.AddRange(new List<Client>
            {
                new Client { ClientID = Guid.NewGuid(), Name = "Paulo", Address="Teste", Age = 44, DocumentNumber="125454545", IsActive = true },
                new Client { ClientID = Guid.NewGuid(), Name = "Ana", Address="Rua hum", Age = 46, DocumentNumber="123456789", IsActive = false },
                new Client { ClientID = Guid.NewGuid(), Name = "Pedro", Address="Av. teste", Age = 30, DocumentNumber="1234567887", IsActive = false },
            });

                context.SaveChanges();
            }

            var mockMapper = new Mock<IMapper>();

            using (var context = new APIDbContext(options))
            {
                var controller = new ClientController(context, mockMapper.Object);

                // Act
                var result = controller.GetClientNotActive();

                // Assert
                Assert.IsType<OkObjectResult>(result);
                Assert.NotNull(result);
            }
        }

        [Fact]
        public void GetClientNotActive_ReturnsOkResult()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<APIDbContext>()
             .UseInMemoryDatabase(databaseName: "InMemory_Test_Database")
             .Options;

            var context = new APIDbContext(options);

            context.Clients.AddRange(new AutoFaker<Client>()
                .Generate());

            context.SaveChanges();

            var mockMapper = new Mock<IMapper>();

            var controller = new ClientController(context, mockMapper.Object);

            // Act
            var result = controller.GetClientActive();

            // Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(result);
        }

        [Fact]
        public void GetClientID_ReturnsOKResult()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<APIDbContext>()
             .UseInMemoryDatabase(databaseName: "InMemory_Test_Database")
             .Options;

            var context = new APIDbContext(options);
            var id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f11af99");

            context.Clients.AddRange(new AutoFaker<Client>()
            .RuleFor(o => o.ClientID, id)
            .Generate());

            // context.SaveChanges();

            var mockMapper = new Mock<IMapper>();

            var controller = new ClientController(context, mockMapper.Object);

            // Act
            var result = controller.GetClient(id);

            Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(result);
        }
        [Fact]
        public void GetClientID_ReturnsNotFoundResult()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<APIDbContext>()
             .UseInMemoryDatabase(databaseName: "InMemory_Test_Database")
             .Options;

            var context = new APIDbContext(options);

            context.Clients.AddRange(new AutoFaker<Client>()
                .Generate());

            context.SaveChanges();

            var mockMapper = new Mock<IMapper>();

            var controller = new ClientController(context, mockMapper.Object);

            // Act
            var result = controller.GetClient(Guid.NewGuid());

            Assert.IsType<NotFoundResult>(result);
            Assert.NotNull(result);
        }


        private static void MockSuccessGetGendersFromDb(Mock<IAPIDbContext> dbManagerMock)
        {
            var clientModel = new AutoFaker<Client>()
                .Generate(3);
            dbManagerMock
                .Setup(s => s.SaveChanges())
                .Returns(clientModel);
        }
    }
}
