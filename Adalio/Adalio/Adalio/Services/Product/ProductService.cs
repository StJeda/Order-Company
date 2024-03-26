namespace Adalio.Services.Product
{
    using Adalio.Data;
    using Domain.Models;
    using Microsoft.EntityFrameworkCore;

    public class ProductService(DataContext context) : IProductService
    {
        private readonly DataContext _context = context;
        public async Task<bool> AddProduct(Product addProduct)
        {
            try
            {
                if (addProduct is null)
                    throw new ArgumentNullException();
                await _context.Products.AddAsync(addProduct);
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }

        public async Task<bool> DeleteProduct(int id)
        {
            try
            {
                var selProduct = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
                if (selProduct is null)
                    throw new ArgumentNullException();
                _context.Products.Remove(selProduct);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }

        public async Task<List<Product>?> GetAllProducts()
            => await _context.Products.ToListAsync();
        public async Task<Product?> GetSingleProduct(int id)
        {
            try
            {
                var selProduct = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
                if (selProduct is null)
                    throw new ArgumentNullException();
                return selProduct;
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
                var selProduct = await _context.Products.FirstOrDefaultAsync(x => x.Id == updateProduct.Id);
                if (selProduct is null)
                    throw new ArgumentNullException();
                selProduct.Name = updateProduct.Name;
                selProduct.Description = updateProduct.Description;
                selProduct.Price = updateProduct.Price;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }
    }
}
