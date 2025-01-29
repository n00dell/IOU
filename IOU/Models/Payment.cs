
namespace IOU.Models
{
    public class Payment
    {
        public string Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentStatus Status { get; set; }
        public string TransactionReference { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public decimal PrincipalPortion { get; set; }
        public decimal InterestPortion { get; set; }
        public decimal LateFeePortion { get; set; }
        public User PaidBy { get; set; }
        public Debt Debt { get; set; }
    }
    public enum PaymentStatus
    {
        Pending,
        Completed,
        Failed,
        Refunded
    }
    public enum PaymentMethod
    {
        BankTransfer,
        CreditCard,
        DebitCard,
        Cash,
        MobileMoney
    }
}
