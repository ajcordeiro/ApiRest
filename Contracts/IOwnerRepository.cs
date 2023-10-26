using Entities.Models;

namespace Contracts
{
    public interface IClientRepository : IRepositoryBase<Client>
    {
        IEnumerable<Client> GetAllClients();
        Client GetClientById(Guid clientId);
        Client GetClientWhitDetails(Guid clientId);
        void CreateClient(Client clientId);
        void UpdateClient(Client clientId);
        void DeleteClient(Client clientId);
    }
}
