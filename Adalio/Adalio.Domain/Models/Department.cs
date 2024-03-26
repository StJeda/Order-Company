using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adalio.Domain.Models
{
    public class Department
    {
        public Department()
        {
            GetCount();
        }
        
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Adress {  get; set; }
        public required int EmployeesNum;
        //public required 
        public List<Importer> Importers { get; set; }
        public List<OrderLine> OrderLines { get; set; }

        private void GetCount()
        {
           EmployeesNum = Importers.Count();
        }
    }
}
