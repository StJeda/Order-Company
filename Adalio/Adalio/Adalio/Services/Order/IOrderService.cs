namespace Adalio.Services.Order
{
    using Domain.Models;
    public interface IOrderService
    {
        public Task<Order?> GetSingleOrder(int id);
        public Task<List<Order>?> GetAllOrders();
        public Task<bool>  AddOrder(Order addOrder);
        public Task<bool> DeleteOrder(int id);
        public Task<bool> UpdateOrder(Order updateOrder);

    }
}