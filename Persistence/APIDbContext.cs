using Microsoft.EntityFrameworkCore;
using WebTest.Entities;
using WebTest.Models;

namespace WebTest.Persistence
{
    public class APIDbContext : DbContext, IAPIDbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }

        public DbSet<ClientInputModel> ClientInputModels { get; set; }

        IQueryable<T> IAPIDbContext.Set<T>()
        {
            throw new NotImplementedException();
        }
    }
}
