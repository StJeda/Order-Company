using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adalio.Domain.Models
{
    public class Importer()
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string Adress {  get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }

        public double[] Marks { get; set; }
        public Account? workAccount { get; set; }

        public double GetAverage()
            => Marks.Average(); 
    }
}
