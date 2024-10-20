using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_IOU.Models
{
    internal class ScheduledPayment
    {
        public string Id { get; set; }
        public PaymentSchedule Schedule { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Amount { get; set; }
        public bool IsPaid { get; set; }
        public Payment Payment { get; set; }
    }
}
