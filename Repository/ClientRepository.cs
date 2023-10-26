using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }


        public IEnumerable<Client> GetAllClients()
        {
            return FindAll()
                 .OrderBy(cl => cl.Name)
                 .ToList();
        }

        public Client GetClientById(Guid clientId)
        {
            return FindByCondition(cl => cl.ClientId.Equals(clientId))
                 .FirstOrDefault();
        }

        public Client GetClientWhitDetails(Guid clientId)
        {
            return FindByCondition(cl => cl.ClientId.Equals(clientId))
                .Include(ac => ac.Accounts)
                .FirstOrDefault();
        }
        public void CreateClient(Client client)
        {
            Create(client);
        }

        public void UpdateClient(Client client)
        {
            Update(client);
        }

        public void DeleteClient(Client client)
        {
            Delete(client);
        }
    }
}
