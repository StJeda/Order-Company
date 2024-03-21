using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adalio.Domain.Models.Enums.Order
{
    public enum OrderStatus
    {
        New,
        Pending,
        Processing,
        Shipped,
        Delivered,
        Cancelled
    }
}
