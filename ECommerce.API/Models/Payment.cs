namespace ECommerce.API.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public string Method { get; set; } = null!; // card, paypal, cash
        public string Status { get; set; } = "pending"; // pending, completed, failed
        public decimal Amount { get; set; }
        public DateTime? PaidAt { get; set; }

        // Navigation property
        public Order? Order { get; set; }
    }
}
