using System;

namespace PaymentSystem.Core.Models
{
    public class Payments
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}