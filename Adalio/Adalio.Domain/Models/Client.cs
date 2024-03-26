using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adalio.Domain.Models
{
    public class Client
    {
        public Client()
        {
            
        }
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public string? Adress { get; set; }
        public required string Email { get; set; }
        public List<Order>? Orders { get; set; }
        public List<Account>? Accounts { get; set; } 
    }
}
