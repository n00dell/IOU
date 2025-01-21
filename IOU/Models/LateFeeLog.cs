

namespace IOU.Models
{
    class LateFeeLog
    {
        public string Id { get; set; }
        public Debt Debt { get; set; }
        public DateTime AssessmentDate { get; set; }
        public decimal FeeAmount { get; set; }
        public int DaysLate { get; set; }
        public string Reason { get; set; }
    }
}
