using Microsoft.EntityFrameworkCore;
using WebTest.Entities;
using WebTest.Models;

namespace WebTest.Persistence
{
    public interface IAPIDbContext 
    {
       public  DbSet<Client> Clients { get; set; }

       public  DbSet<ClientInputModel> ClientInputModels { get; set; }

        IQueryable<T> Set<T>() where T : class;

       public string SaveChanges();
    }
}
