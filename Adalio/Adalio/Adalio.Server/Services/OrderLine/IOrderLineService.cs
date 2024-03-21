namespace Adalio.Services.OrderLine
{
    using Domain.Models;
    public interface IOrderLineService
    {
        public Task<OrderLine?> GetSingleOrderLine(Guid id);
        public Task<List<OrderLine>?> GetAllOrderLines();

        public Task<bool> AddOrderLine(OrderLine addOrderLine);
        public Task<bool> DeleteOrderLine(Guid id);
        public Task<bool> UpdateOrderLine(OrderLine updateOrderLine);
    }
}
