using Adalio.Domain.Models.Enums;
using Adalio.Domain.Models.Enums.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adalio.Domain.Models
{
    public class Order
    {
        //[primary]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatingDate { get; set; }
        public OrderStatus Status { get; set; }
        public int Priority { get; set; }
        public ShippingMethod ShippingMethod { get; set; }
        public List<Tag>? Tags { get; set; }
        public List<Product>? Products { get; set; }
        
    }
}
