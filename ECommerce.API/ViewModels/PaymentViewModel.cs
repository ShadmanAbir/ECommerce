using ECommerce.API.Models;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.API.ViewModels
{
    public class PaymentViewModel
    {
        [Key]
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public string Method { get; set; } = null!; // card, paypal, cash
        public string Status { get; set; } = "pending"; // pending, completed, failed
        public decimal Amount { get; set; }
        public DateTime? PaidAt { get; set; }

        // Navigation property
        public OrderViewModel? Order { get; set; }
    }
}
