namespace Adalio.Services.Client
{
    using Domain.Models;
    public class ClientService() : IClientService
    {
        public async Task<bool> AddClient(Client addClient)
        {
            try
            {
                if (addClient is null)
                    throw new ArgumentNullException();
                await dbContext.AddClientAsync(addClient);
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
                var selClient = await dbContext.GetClientByIdAsync(id);
                if (selClient is null)
                    throw new ArgumentNullException();
                await dbContext.DeleteClientAsync(selClient);
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }

        public async Task<List<Client>?> GetAllClients()
            => await dbContext.GetAllClientsAsync();

        public async Task<Client?> GetSingleClient(int id)
        {
            try
            {
                var selClient = await dbContext.GetClientByIdAsync(id);
                if (selClient is null)
                    throw new ArgumentNullException();
                return Task.FromResult(selClient);
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
                var selClient = await dbContext.GetClientByIdAsync(updateClient.Id);
                if (selClient is null)
                    throw new ArgumentNullException();
                await dbContext.UpdateClientAsync(selClient);
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }
    }
}
