namespace Adalio.Services.OrderLine
{
    using Adalio.Data;
    using Domain.Models;
    using Microsoft.AspNetCore.Http.Features;
    using Microsoft.EntityFrameworkCore;

    public class OrderLineService(DataContext context) : IOrderLineService
    {
        private readonly DataContext _context = context;
        public async Task<bool> AddOrderLine(OrderLine addOrderLine)
        {
            try
            {
                if (addOrderLine is null)
                    throw new ArgumentNullException();
                await _context.orderLines.AddAsync(addOrderLine);
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }


        public async Task<bool> DeleteOrderLine(int id)
        {
            try
            {
                var selOrderLine = await _context.orderLines.FirstOrDefaultAsync(x => x.Id == id);
                if (selOrderLine is null)
                    throw new ArgumentNullException();
                _context.Remove(selOrderLine);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }

        public async Task<List<OrderLine>?> GetAllOrderLines()
            => await _context.orderLines.ToListAsync();

        public async Task<OrderLine?> GetSingleOrderLine(int id)
        {
            try
            {
                var selOrderLine = await _context.orderLines.FirstOrDefaultAsync(x => x.Id == id);
                if (selOrderLine is null)
                    throw new ArgumentNullException();
                return selOrderLine;
            }
            catch (ArgumentNullException ex)
            {
                return null;
            }
        }

        public async Task<bool> UpdateOrderLine(OrderLine updateOrderLine)
        {
            try
            {
                var selOrderLine = await _context.orderLines.FirstOrDefaultAsync(x => x.Id == updateOrderLine.Id);
                if (selOrderLine is null)
                    throw new ArgumentNullException();
                selOrderLine.Orders = updateOrderLine.Orders;
                selOrderLine.Priority = updateOrderLine.Priority;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (ArgumentNullException ex)
            {
                return false;
            }
        }
    }
}
