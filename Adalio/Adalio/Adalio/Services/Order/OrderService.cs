namespace Adalio.Services.Order
{
    using Adalio.Data;
    using Adalio.Domain.Models.Enums.Order;
    using Adalio.Exceptions;
    using Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using System;

    public class OrderService(DataContext context) : IOrderService
    {
        private readonly DataContext _context = context;
        public async Task<List<Order>?> GetAllOrders()
            => await _context.Orders.ToListAsync();

        public async Task<Order?> GetSingleOrder(int id)
        {
            try
            {
                var selOrder = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
                if (selOrder is null)
                    throw new ArgumentNullException();
                return selOrder;
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
                await _context.Orders.AddAsync(addOrder);
                await _context.SaveChangesAsync();
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
                var selOrder = await _context.Orders.FirstOrDefaultAsync(x => x.Id == updateOrder.Id);
                if (selOrder is null)
                    throw new ArgumentNullException();
                selOrder.Priority = updateOrder.Priority;
                selOrder.Status = updateOrder.Status;
                selOrder.ShippingMethod = updateOrder.ShippingMethod;
                selOrder.Products = updateOrder.Products;
                selOrder.CreatingDate = selOrder.CreatingDate;
                selOrder.Name = updateOrder.Name;
                selOrder.Tags = updateOrder.Tags;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }

        public async Task<bool> DeleteOrder(int id)
        {
            try
            {
                var selOrder = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
                if (selOrder is null)
                    throw new ArgumentNullException();
                if (selOrder.Status != OrderStatus.New)
                    throw new NotNewException();
                _context.Remove(selOrder);
                await _context.SaveChangesAsync();
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
