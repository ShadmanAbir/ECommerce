using ECommerce.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Services
{
    public class OrderService
    {
        private readonly ECommerceContext _context;

        public OrderService(ECommerceContext context)
        {
            _context = context;
        }

        // Create new order
        public async Task<Order> CreateAsync(Order order)
        {
            order.CreatedAt = DateTime.UtcNow;
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        // Get order by Id
        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.OrderId == id);
        }

        // Get all orders for a user
        public async Task<List<Order>> GetOrdersByUserAsync(int userId)
        {
            return await _context.Orders
                .Where(o => o.UserId == userId)
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .AsNoTracking()
                .ToListAsync();
        }

        // Update order status
        public async Task<Order?> UpdateAsync(int id, string status)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return null;

            order.Status = status;
            order.CreatedAt = DateTime.UtcNow;

            _context.Orders.Update(order);
            await _context.SaveChangesAsync();

            return order;
        }

        // Delete (cancel) order
        public async Task<bool> DeleteAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return false;

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
