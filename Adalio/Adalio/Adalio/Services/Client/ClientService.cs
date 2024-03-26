namespace Adalio.Services.Client
{
    using Adalio.Data;
    using Domain.Models;
    using Microsoft.EntityFrameworkCore;

    public class ClientService(DataContext context) : IClientService
    {
        private readonly DataContext _context = context;
        public async Task<bool> AddClient(Client addClient)
        {
            try
            {
                if (addClient is null)
                    throw new ArgumentNullException();
                await _context.Clients.AddAsync(addClient);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }

        public async Task<bool> DeleteClient(int id)
        {
            try
            {
                var selClient = await _context.Clients.FirstOrDefaultAsync(x => x.Id == id);
                if (selClient is null)
                    throw new ArgumentNullException();
                _context.Remove(selClient);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }

        public async Task<List<Client>?> GetAllClients()
            => await _context.Clients.ToListAsync();

        public async Task<Client?> GetSingleClient(int id)
        {
            try
            {
                var selClient = await _context.Clients.FirstOrDefaultAsync(x => x.Id == id);
                if (selClient is null)
                    throw new ArgumentNullException();
                return selClient;
            }
            catch (ArgumentNullException)
            {
                return null;
            }
        }

        public async Task<bool> UpdateClient(Client updateClient)
        {
            try
            {
                var selClient = await _context.Clients.FirstOrDefaultAsync(x => x.Id == updateClient.Id);
                if (selClient is null)
                    throw new ArgumentNullException();
                selClient.Adress = updateClient.Adress;
                selClient.Accounts = updateClient.Accounts;
                selClient.Orders = updateClient.Orders;
                selClient.Email = updateClient.Email;
                selClient.LastName = updateClient.LastName;
                selClient.Name = updateClient.Name;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }
    }
}
