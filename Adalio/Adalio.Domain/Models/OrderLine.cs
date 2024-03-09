using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adalio.Domain.Models
{
    public class OrderLine
    {
        public Guid Id { get; set; }
        public List<Order> Orders { get; set; }
        public int Priority {  get; set; }
    }
}
