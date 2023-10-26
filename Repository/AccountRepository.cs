using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public IEnumerable<Account> AccountsByClient(Guid clientId)
        {
            return FindByCondition(a => a.ClientId.Equals(clientId)).ToList();
        }
    }
}
