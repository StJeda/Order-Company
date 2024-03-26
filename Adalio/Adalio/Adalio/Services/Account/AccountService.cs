namespace Adalio.Services.Account
{
    using Adalio.Data;
    using Adalio.Exceptions;
    using Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Identity.Client;

    public class AccountService(DataContext context) : IAccountService
    {
        private readonly DataContext _context = context;

        public async Task<List<Account>?> GetAllAccounts()
            => await _context.Accounts.ToListAsync();

        public async Task<Account?> GetSingleAccount(int id)
        {
            try
            {
                var selAccount = await _context.Accounts.FirstOrDefaultAsync(x => x.Id == id);
                if (selAccount is null)
                    throw new ArgumentNullException();
                return selAccount;
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
                await _context.Accounts.AddAsync(addAccount);
                await _context.SaveChangesAsync();
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
                var selAccount = await _context.Accounts.FirstOrDefaultAsync(x => x.Id == updateAccount.Id);
                if (selAccount is null)
                    throw new ArgumentNullException();
                selAccount.AdditionalEmail = updateAccount.AdditionalEmail;
                selAccount.Phone = updateAccount.Phone;
                selAccount.Email = updateAccount.Email;
                selAccount.Password = updateAccount.Password;
                selAccount.UserName = updateAccount.UserName;
                selAccount.Abonement = updateAccount.Abonement;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAccount(int id)
        {
            try
            {
                var selAccount = await _context.Accounts.FirstOrDefaultAsync(x => x.Id == id);
                if (selAccount is null)
                    throw new ArgumentNullException();
                if (selAccount.Phone is null)
                {
                    throw new NotPhoneException();
                }
                _context.Accounts.Remove(selAccount);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (ArgumentNullException)
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
