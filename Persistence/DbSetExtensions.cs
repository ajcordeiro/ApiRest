using Microsoft.EntityFrameworkCore;
using Moq;

namespace WebTest.Persistence
{
    public static class DbSetExtensions
    {
        public static Mock<DbSet<T>> ReturnsDbSet<T>(this Mock<IAPIDbContext> dbContext, List<T> list) where T : class
        {
            var dbSet = new Mock<DbSet<T>>();

            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(list.AsQueryable().Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(list.AsQueryable().Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(list.AsQueryable().ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());

            dbContext.Setup(c => c.Set<T>()).Returns(dbSet.Object);
            return dbSet;
        }
    }
}
