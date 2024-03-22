using Adalio.Domain.Models;
using Adalio.Services.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Adalio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController (IAccountService service): ControllerBase
    {
        private readonly IAccountService _service = service;

        [HttpGet]
        public async Task<IEnumerable<Account>?> GetAll()
            => await _service.GetAllAccounts();

        [HttpGet("{Guid}")]
        public async Task<ActionResult<Account?>> Get(Guid guid)
            => Ok(await _service.GetSingleAccount(guid));

        [HttpPost]
        public async Task<bool> Add(Account account)
            => await _service.AddAccount(account);

        [HttpPut]
        public async Task<bool> Update(Account account)
            => await _service.UpdateAccount(account);

        [HttpDelete]
        public async Task<bool> Delete(Guid guid)
            => await _service.DeleteAccount(guid);
    }
}
