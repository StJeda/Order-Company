using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adalio.Domain.Models.Enums
{
    enum orderStatus
    {
        Pending,
        Processing,
        Shipped,
        Delivered,
        Cancelled
    }
    enum shippingMethod
    {
        Standard,
        Express,
        NextDay,
        Pickup
    }
    internal class OrdersEnums
    {
    }
}
