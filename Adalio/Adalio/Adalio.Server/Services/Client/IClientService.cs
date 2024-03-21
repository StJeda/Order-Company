
namespace Adalio.Services.Client
{
    using Domain.Models;
    public interface IClientService
    {
        public Task<Client?> GetSingleClient(Guid  id);
        public Task<List<Client>?> GetAllClients();

        public Task<bool> AddClient(Client addClient);
        public Task<bool> DeleteClient(Guid id);
        
        public Task<bool> UpdateClient(Client updateClient);


    
    }
}
