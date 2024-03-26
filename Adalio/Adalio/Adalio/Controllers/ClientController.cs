using Adalio.Services.Client;
using Microsoft.AspNetCore.Mvc;
namespace Adalio.Controllers
{
    using Adalio.Domain.Models;
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController(IClientService service) : ControllerBase
    {
        private readonly IClientService _service = service;

        [HttpGet]
        public async Task<IEnumerable<Client>?> GetAll()
            => await _service.GetAllClients();
        [HttpGet("{Guid}")]
        public async Task<ActionResult<Client?>> GetSingle(int id)
            => await _service.GetSingleClient(id);
        [HttpPost]
        public async Task<bool> Add(Client client)
            => await _service.AddClient(client);
        [HttpPut]
        public async Task<bool> Update(Client client)
            => await _service.UpdateClient(client);
        [HttpDelete]
        public async Task<bool> Delete(int id)
            => await _service.DeleteClient(id);
    }
}
