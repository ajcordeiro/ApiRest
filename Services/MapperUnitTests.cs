using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using WebTest.Entities;
using WebTest.Mapper;
using WebTest.Models;

namespace WebTest.Tests.Services
{
    public class MapperUnitTests
    {
        [Fact]
        public void AutoMapper_Configuration_IsValid()
        {
            var services = new ServiceCollection();
            services.AddAutoMapper(typeof(MapperProfile));

            var serviceProvider = services.BuildServiceProvider();

            var mapper = serviceProvider.GetRequiredService<IMapper>();

            var client = new Client();
            var clientViewModel = mapper.Map<ClientViewModel>(client);

            Assert.NotNull(clientViewModel);
        }
    }
}
