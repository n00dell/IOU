namespace IOU.API.Models
{
    public class ScheduledPayment
    {
        public string Id { get; set; }
        public PaymentSchedule Schedule { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Amount { get; set; }
        public bool IsPaid { get; set; }
        public Payment Payment { get; set; }
    }
}
