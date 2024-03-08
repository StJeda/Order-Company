using Adalio.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adalio.Domain.Models
{
    internal class Order
    {
        Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime creatingDate { get; set; }
        public orderStatus Status { get; set; }
        public int Priority { get; set; }

        public List<Product> products;
        
    }
}
