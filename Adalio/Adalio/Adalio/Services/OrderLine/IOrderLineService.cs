namespace Adalio.Services.OrderLine
{
    using Domain.Models;
    public interface IOrderLineService
    {
        public Task<OrderLine?> GetSingleOrderLine(int id);
        public Task<List<OrderLine>?> GetAllOrderLines();

        public Task<bool> AddOrderLine(OrderLine addOrderLine);
        public Task<bool> DeleteOrderLine(int id);
        public Task<bool> UpdateOrderLine(OrderLine updateOrderLine);
    }
}
