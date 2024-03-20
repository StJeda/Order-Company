namespace Adalio.Services.Product
{
    using Domain.Models;
    public interface IProductService
    {
        public Task<Product?> GetSingleProduct(int id);
        public Task<List<Importer>?> GetAllProducts();

        public Task<bool> AddProduct(Product addProduct);
        public Task<bool> DeleteProduct(int id);
        public Task<bool> UpdateProduct(Importer updateProduct);
    }
}
