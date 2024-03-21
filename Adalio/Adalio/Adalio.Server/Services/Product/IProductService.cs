namespace Adalio.Services.Product
{
    using Domain.Models;
    public interface IProductService
    {
        public Task<Product?> GetSingleProduct(Guid id);
        public Task<List<Product>?> GetAllProducts();

        public Task<bool> AddProduct(Product addProduct);
        public Task<bool> DeleteProduct(Guid id);
        public Task<bool> UpdateProduct(Product updateProduct);
    }
}
