namespace Adalio.Services.OrderLine
{
    using Domain.Models;
    public class OrderLineService() : IOrderLineService
    {
        public async Task<bool> AddOrderLine(OrderLine addOrderLine)
        {
            try
            {
                if (addOrderLine is null)
                    throw new ArgumentNullException();
                await dbContext.AddOrderLineAsync();
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }


        public async Task<bool> DeleteOrderLine(Guid id)
        {
            try
            {
                var selOrderLine = await dbContext.GetOrderLineByIdAsync(id);
                if (selOrderLine is null)
                    throw new ArgumentNullException();
                await dbContext.DeleteOrderLineAsync(selOrderLine);
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }

        public async Task<List<OrderLine>?> GetAllOrderLines()
            => await dbContext.GetAllOrderLinesAsync();

        public async Task<OrderLine?> GetSingleOrderLine(Guid id)
        {
            try
            {
                var selOrderLine = await dbContext.GetOrderLineByIdAsync(id);
                if (selOrderLine is null)
                    throw new ArgumentNullException();
                return Task.FromResult(selOrderLine);
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
                var selOrderLine = await dbContext.GetOrderLineByIdAsync(updateOrderLine.id);
                if (selOrderLine is null)
                    throw new ArgumentNullException();
                await dbContext.UpdateOrderLineAsync(selOrderLine);
                return true;
            }
            catch (ArgumentNullException ex)
            {
                return false;
            }
        }
    }
}
