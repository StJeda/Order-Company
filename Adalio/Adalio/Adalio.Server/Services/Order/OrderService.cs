namespace Adalio.Services.Order
{
    using Adalio.Domain.Models.Enums.Order;
    using Adalio.Exceptions;
    using Domain.Models;
    using System;

    public class OrderService : IOrderService   
    {
        public async Task<List<Order>?> GetAllOrders()
            => await dbContext.GetAllOrdersAsync();

        public async Task<Order?> GetSingleOrder(Guid id)
        {
            try
            {
                var selOrder = await dbContext.GetOrderByIdAsync(id);
                if (selOrder is null)
                    throw new ArgumentNullException();
                return Task.FromResult(selOrder);
            }
            catch (ArgumentNullException) 
            {
                return null;
            }
        }

        public async Task<bool> AddOrder(Order addOrder)
        {
            try
            {
                if (addOrder is null)
                    throw new ArgumentNullException();
                await dbContext.AddOrderAsync();
                return true;
            }
            catch (ArgumentNullException) 
            {
                return false;
            }
        }

        public async Task<bool> UpdateOrder(Order updateOrder)
        {
            try
            {
                var selOrder = await dbContext.GetOrderByIdAsync(updateOrder.Id);
                if (selOrder is null)
                    throw new ArgumentNullException();
                await dbContext.UpdateOrderAAsync(selOrder);
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }

        public async Task<bool> DeleteOrder(Guid id)
        {
            try
            {
                var selOrder = await dbContext.GetOrderByIdAsync(id);
                if (selOrder is null)
                    throw new ArgumentNullException();
                if (selOrder.Status != OrderStatus.New)
                    throw new NotNewException();
                await dbContext.DeleteOrderAsync(selOrder);
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
            catch (NotNewException)
            {
                return false;
            }
        }
        
    }
}
