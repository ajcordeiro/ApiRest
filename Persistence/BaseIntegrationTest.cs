using Moq;

namespace WebTest.Persistence
{
    public abstract class BaseIntegrationTest
    {
        protected static Mock<IAPIDbContext> GetRestManagerMock() => new Mock<IAPIDbContext>();
    }
}
