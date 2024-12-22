namespace IOU.API.Models
{
    public class InterestLog
    {
        public string Id { get; set; }
        public Debt Debt { get; set; }
        public DateTime CalculationDate { get; set; }
        public decimal PrincipalAmount { get; set; }
        public decimal InterestAmount { get; set; }
        public decimal InterestRate { get; set; }
        public int DaysCounted { get; set; }
    }
}
