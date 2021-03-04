using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vodovoz.Models.ClientSide.Database
{
    public class Order
    {
        [Key]
        public int Number { get; set; }
        public string CounterAgent { get; set; }
        public DateTime OrderTime { get; set; }
        public Employee Author { get; set; }
    }
}
