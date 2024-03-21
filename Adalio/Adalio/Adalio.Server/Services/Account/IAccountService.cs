namespace Adalio.Services.Account
{
    using Domain.Models;
    public interface IAccountService
    {
        public Task<Account?> GetSingleAccount(Guid id);
        public Task<List<Account>?> GetAllAccounts();
        public Task<bool> AddAccount(Account addAccount);
        public Task<bool> DeleteAccount(Guid id);
        public Task<bool> UpdateAccount(Account updateAccount);
    }
}
