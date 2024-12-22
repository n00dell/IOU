namespace IOU.API.Models
{
    public class PaymentSchedule
    {
        public string Id { get; set; }
        public Debt Debt { get; set; }
        public PaymentFrequency Frequency { get; set; }
        public decimal InstallmentAmount { get; set; }
        public int TotalInstallments { get; set; }
        public int CompletedInstallments { get; set; }
        public List<ScheduledPayment> ScheduledPayments { get; set; }
    }
}
