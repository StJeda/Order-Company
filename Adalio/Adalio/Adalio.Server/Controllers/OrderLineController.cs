using Adalio.Domain.Models;
using Adalio.Services.OrderLine;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Adalio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderLineController(IOrderLineService service) : ControllerBase
    {
        private readonly IOrderLineService _service = service;

        [HttpGet]
        public async Task<IEnumerable<OrderLine>?> GetAll()
            => await _service.GetAllOrderLines();
        [HttpGet("{Guid}")]
        public async Task<ActionResult<OrderLine>> GetSingle(Guid guid)
            => Ok(await _service.GetSingleOrderLine(guid));
        [HttpPost]
        public async Task<bool> Add(OrderLine orderLine) 
            => await _service.AddOrderLine(orderLine);
        [HttpPut]
        public async Task<bool> Update(OrderLine orderLine)
            => await _service.UpdateOrderLine(orderLine);
        [HttpDelete]
        public async Task<bool> Delete(Guid guid) 
            => await _service.DeleteOrderLine(guid);
    }
}
