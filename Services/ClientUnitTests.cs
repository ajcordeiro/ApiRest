using AutoBogus;
using WebTest.Entities;
using WebTest.Models;

namespace WebTest.Tests.Services
{
    public class ClientUnitTests
    {
        [Fact]
        public void Client_OK()
        {
            var result = new AutoFaker<Client>()
                .Generate();

            Assert.NotNull(result);
        }

        [Fact]
        public void ClientInputModel_OK()
        {
            var result = new AutoFaker<ClientInputModel>()
                .Generate();

            Assert.NotNull(result);
        }

        [Fact]
        public void ClientViewModel_OK()
        {
            var result = new AutoFaker<ClientViewModel>()
                .Generate();

            Assert.NotNull(result);
        }
    }
}
