

namespace IOU.Models
{
   public class Debt
    {
        public string Id { get; set; }
        public decimal Amount { get; set; }
        public decimal RemainingAmount { get; set; }

        public string Description { get; set; }

        public DateTime DateIssued { get; set; }
        public DateTime DueDate { get; set; }
        public DebtStatus Status { get; set; }
        public Student Student { get; set; }
        public Lender Lender { get; set; }
        public List<Payment> Payments { get; set; }
        public List<DebtNotification> Notifications { get; set; }
        // Interest related properties
        public decimal InterestRate { get; set; }  // Annual interest rate as a percentage
        public InterestType InterestType { get; set; }  // Simple or Compound
        public InterestCalculationPeriod CalculationPeriod { get; set; }  // Monthly, Quarterly, Annually
        public DateTime LastInterestCalculationDate { get; set; }
        public decimal AccumulatedInterest { get; set; }

        // Late fee related properties
        public decimal LateFeeAmount { get; set; }  // Fixed amount
        public decimal LateFeePercentage { get; set; }  // Percentage of principal
        public LateFeeType LateFeeType { get; set; }  // Fixed or Percentage
        public int GracePeriodDays { get; set; }  // Days before late fee applies
        public decimal AccumulatedLateFees { get; set; }
        // Payment schedule
        public PaymentSchedule PaymentSchedule { get; set; }

        // Navigation properties

        public List<InterestLog> InterestLogs { get; set; }
        public List<LateFeeLog> FeeLogs { get; set; }

    }
    public enum DebtStatus
    {
        Active,
        Overdue,
        Paid,
        Defaulted,
        InDispute
    }
    public enum InterestType
    {
        Simple,
        Compound
    }
    public enum InterestCalculationPeriod
    {
        Daily,
        Monthly,
        Quarterly,
        Annually
    }
    public enum LateFeeType
    {
        Fixed,
        Percentage,
        Both
    }
    public enum PaymentFrequency
    {
        Weekly,
        Biweekly,
        Monthly,
        Quarterly,
        Annually
    }
}

