using Adalio.Domain.Models.Enums.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adalio.Domain.Models
{
    public class Account
    {
        public Guid Id { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string  Email { get; set; }

        public required Abonement Abonement { get; set; } 
        public string? AdditionalEmail { get; set; }
        public string? Phone { get; set; }


    }
}
