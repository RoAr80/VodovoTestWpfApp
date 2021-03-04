using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vodovoz.Models.ClientSide.Database
{
    public class Subdivision
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Employee Manager { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
