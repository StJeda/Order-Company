namespace Adalio.Services.OrderLine
{
    using Domain.Models;
    public interface IOrderLineService
    {
        public Task<OrderLine?> GetSingleOrderLine(int id);
        public Task<List<Importer>?> GetAllOrderLines();

        public Task<bool> AddOrderLine(Importer addImporter);
        public Task<bool> DeleteOrderLine(int id);
        public Task<bool> UpdateOrderLine(Importer updateImporter);
    }
}
