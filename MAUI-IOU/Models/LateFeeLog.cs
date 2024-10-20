using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_IOU.Models
{
    internal class LateFeeLog
    {
        public string Id { get; set; }
        public Debt Debt { get; set; }
        public DateTime AssessmentDate { get; set; }
        public decimal FeeAmount { get; set; }
        public int DaysLate { get; set; }
        public string Reason { get; set; }
    }
}
