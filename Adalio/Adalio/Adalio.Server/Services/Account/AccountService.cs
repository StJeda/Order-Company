namespace Adalio.Services.Account
{
    using Adalio.Exceptions;
    using Domain.Models;
    public class AccountService : IAccountService
    {
        public async Task<List<Account>?> GetAllAccounts()
            => await dbContext.GetAllAccountsAsync();

        public async Task<Account?> GetSingleAccount(Guid id)
        {
            try
            {
                var selAccount = await dbContext.GetAccountByIdAsync(id);
                if (selAccount is null)
                    throw new ArgumentNullException();
                return Task.FromResult(selAccount);
            }
            catch (ArgumentNullException)
            {
                return null;
            }
        }

        public async Task<bool> AddAccount(Account addAccount)
        {
            try
            {
                if (addAccount is null)
                    throw new ArgumentNullException();
                //TODO: check to enter the number.
                await dbContext.AddAccountAsync();
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAccount(Account updateAccount)
        {
            try
            {
                var selAccount = await dbContext.GetAccountByIdAsync(updateAccount.Id);
                if (selAccount is null)
                    throw new ArgumentNullException();
                await dbContext.UpdateAccountAsync(selAccount);
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAccount(Guid id)
        {
            try
            {
                var selAccount = await dbContext.GetAccountByIdAsync(id);
                if (selAccount is null)
                    throw new ArgumentNullException();
                if(selAccount.Phone is null)
                {
                    throw new NotPhoneException();
                }
                await dbContext.DeleteAccountAsync(selAccount);
                return true;
            }
            catch (ArgumentNullException )
            {
                return false;
            }
            catch (NotPhoneException)
            {
                return false;
            }
        }
    }
}
