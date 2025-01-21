
namespace IOU.Models
{
    class ScheduledPayment
    {
        public string Id { get; set; }
        public string ScheduleId { get; set; }
        public PaymentSchedule Schedule { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Amount { get; set; }
        public bool IsPaid { get; set; }

        public string PaymentId { get; set; }
        public Payment Payment { get; set; }
    }
}
