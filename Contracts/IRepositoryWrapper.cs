namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IClientRepository Client { get; }
        IAccountRepository Account { get; }
        void Save();
    }
}
