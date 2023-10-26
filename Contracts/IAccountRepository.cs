using Entities.Models;

namespace Contracts
{
    public interface IAccountRepository :IRepositoryBase<Account>
    {
        IEnumerable<Account> AccountsByClient(Guid clientId);
    }
}
