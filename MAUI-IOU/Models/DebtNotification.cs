using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_IOU.Models
{
    internal class DebtNotification
    {
        public string Id {  get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ReadDate { get; set; }
        public NotificationType Type { get; set; }
        public bool IsRead { get; set; }
        public Debt Debt { get; set; }
        public List<User> Recipients { get; set; }
    }
    public enum NotificationType
    {
        PaymentDue,
        PaymentReceived,
        PaymentOverdue,
        DebtCreated,
        DebtUpdated
    }
}
