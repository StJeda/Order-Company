
using Adalio.Domain.Models;
using Adalio.Services.Order;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Adalio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IOrderService service) : ControllerBase
    {
        private readonly IOrderService _service = service;

        [HttpGet]
        public async Task<IEnumerable<Order>?> GetAll()
            => await _service.GetAllOrders();

        [HttpGet("{Guid}")]
        public async Task<ActionResult<Importer?>> Get(Guid guid)
            => Ok(await _service.GetSingleOrder(guid));

        [HttpPost]
        public async Task<bool> Add(Order order)
            => await _service.AddOrder(order);

        [HttpPut]
        public async Task<bool> Update(Order order)
            => await _service.UpdateOrder(order);

        [HttpDelete]
        public async Task<bool> Delete(Guid guid)
            => await _service.DeleteOrder(guid);
    }
}
