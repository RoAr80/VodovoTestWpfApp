using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vodovoz.Models.ClientSide.Database
{
    public class Employee
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        [Column(TypeName ="date")]
        public DateTime Birthday { get; set; }
        public SexEnum Sex { get; set; }
        public Subdivision Subdivision { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}
