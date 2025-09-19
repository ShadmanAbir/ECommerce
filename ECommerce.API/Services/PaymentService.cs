using ECommerce.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Services
{
    public class PaymentService
    {
        private readonly ECommerceContext _context;

        public PaymentService(ECommerceContext context)
        {
            _context = context;
        }

        // Create a new payment
        public async Task<Payment> CreatePaymentAsync(Payment payment)
        {
            payment.PaidAt = DateTime.UtcNow;
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        // Get payment by Id
        public async Task<Payment?> GetPaymentByIdAsync(int id)
        {
            return await _context.Payments
                .Include(p => p.Order)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.PaymentId == id);
        }

        // Get all payments for a user (through orders)
        public async Task<List<Payment>> GetPaymentsByUserAsync(int userId)
        {
            return await _context.Payments
                .Include(p => p.Order)
                .Where(p => p.Order.UserId == userId)
                .AsNoTracking()
                .ToListAsync();
        }

        // Update payment status (e.g., Pending -> Completed)
        public async Task<Payment?> UpdatePaymentStatusAsync(int id, string status)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null) return null;

            payment.Status = status;
            payment.PaidAt = DateTime.UtcNow;

            _context.Payments.Update(payment);
            await _context.SaveChangesAsync();

            return payment;
        }

        // Delete payment (rare, usually for admin/debug)
        public async Task<bool> DeletePaymentAsync(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null) return false;

            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
