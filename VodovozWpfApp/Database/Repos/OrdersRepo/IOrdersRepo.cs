using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vodovoz.Models.ClientSide.Database;

namespace VodovozWpfApp
{
    public interface IOrdersRepo
    {
        IEnumerable<Order> Orders { get; }
        Task<Order> UpdateOrAddOrderAsync(Order Order);
        Task DeleteOrderAsync(Order Order);
    }
}
