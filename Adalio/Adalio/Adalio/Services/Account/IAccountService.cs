namespace Adalio.Services.Account
{
    using Domain.Models;
    public interface IAccountService
    {
        public Task<Account?> GetSingleAccount(int id);
        public Task<List<Account>?> GetAllAccounts();
        public Task<bool> AddAccount(Account addAccount);
        public Task<bool> DeleteAccount(int id);
        public Task<bool> UpdateAccount(Account updateAccount);
    }
}
