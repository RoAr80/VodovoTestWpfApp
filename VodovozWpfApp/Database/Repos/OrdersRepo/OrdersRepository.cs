using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vodovoz.Models.ClientSide.Database;

namespace VodovozWpfApp
{
    public class OrdersRepository : IOrdersRepo
    {
        private VodovozClientDbContext _context;
        public OrdersRepository(VodovozClientDbContext ctx)
        {
            _context = ctx;            
        }
        public IEnumerable<Order> Orders => _context.Orders
            .Include(e => e.Author).ToArray();

        public async Task DeleteOrderAsync(Order Order)
        {
            _context.Orders.Remove(Order);
            await _context.SaveChangesAsync();
        }

        public async Task<Order> UpdateOrAddOrderAsync(Order Order)
        {
            Order order = await _context.Orders.FindAsync(Order.Number);
            bool isItAdd = false;
            if(order != null)
            {
                order.CounterAgent = Order.CounterAgent;
                order.OrderTime = Order.OrderTime;
                order.Author = Order.Author;
            }
            else
            {
                isItAdd = true;
                await _context.Orders.AddAsync(Order);
            }
            await _context.SaveChangesAsync();

            return isItAdd ? Order : null;
        }
    }
}
