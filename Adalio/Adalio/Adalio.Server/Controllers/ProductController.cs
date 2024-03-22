using Adalio.Domain.Models;
using Adalio.Services.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Adalio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService service) : ControllerBase
    {
        private readonly IProductService _service = service;
        [HttpGet] 
        public async Task<IEnumerable<Product>?> GetAll()
            => await _service.GetAllProducts();
        [HttpGet("{Guid}")]
        public async Task<ActionResult<Product?>> Get(Guid guid)
            => Ok(await _service.GetSingleProduct(guid));
        [HttpPost]
        public async Task<bool> Add(Product product)
            => await _service.AddProduct(product);
        [HttpPut]
        public async Task<bool> Update(Product product)
            => await _service.UpdateProduct(product);
        [HttpDelete]
        public async Task<bool> Delete(Guid guid)
            => await _service.DeleteProduct(guid);
        
    }
}
