using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IClientRepository _client;
        private IAccountRepository _account;

        public IClientRepository Client
        {
            get
            {
                if (_client is null)
                {
                    _client = new ClientRepository(_repoContext);
                }
                return _client;
            }
        }

        public IAccountRepository Account
        {
            get
            {
                if (_account is null)
                {
                    _account = new AccountRepository(_repoContext);
                }
                return _account;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext) => _repoContext = repositoryContext;
       
        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
