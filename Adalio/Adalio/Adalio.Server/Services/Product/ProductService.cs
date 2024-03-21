namespace Adalio.Services.Product
{
    using Domain.Models;
    public class ProductService() : IProductService
    {
        public async Task<bool> AddProduct(Product addProduct)
        {
            try
            {
                if (addProduct is null)
                    throw new ArgumentNullException();
                await dbContext.AddProductAsync(addProduct);
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }

        public async Task<bool> DeleteProduct(Guid id)
        {
            try
            {
                var selProduct = await dbContext.GetProductByIdAsync(id);
                if (selProduct is null)
                    throw new ArgumentNullException();
                await dbContext.DeleteProductAsync(selProduct);
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }

        public async Task<List<Product>?> GetAllProducts()
            => await dbContext.GetAllProductsAsync();

        public async Task<Product?> GetSingleProduct(Guid id)
        {
            try
            {
                var selProduct = await dbContext.GetProductByIdAsync(id);
                if (selProduct is null)
                    throw new ArgumentNullException();
                return Task.FromResult(selProduct);
            }
            catch (ArgumentNullException)
            {
                return null;
            }
        }

        public async Task<bool> UpdateProduct(Product updateProduct)
        {
            try
            {
                var selProduct = await dbContext.GetProductByIdAsync(updateProduct.Id);
                if (selProduct is null)
                    throw new ArgumentNullException();
                await dbContext.UpdateProductAsync(selProduct);
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }
    }
}
