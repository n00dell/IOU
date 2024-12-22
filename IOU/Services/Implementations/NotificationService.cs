//using MAUI_IOU.Data;
//using MAUI_IOU.Models;
//using MAUI_IOU.Services.Interfaces;
//using Microsoft.Extensions.Logging;

//namespace MAUI_IOU.Services.Implementations
//{
//    internal class NotificationService: INotificationService
//    {
//        private readonly ILogger<NotificationService> _logger;
//        private readonly IOUContext _context;

//        public NotificationService(ILogger<NotificationService> logger, IOUContext context)
//        {
//            _logger = logger;
//            _context = context;
//        }
//        public async Task SendPaymentDueNotification(Debt debt)
//        {
//            var notification = new DebtNotification
//            {
//                Title = "Payment Due Reminder",
//                Message = $"Your payment of {debt.PaymentSchedule.InstallmentAmount:C} is due on {debt.DueDate:d}",
//                CreatedDate = DateTime.Now,
//                Type = NotificationType.PaymentDue,
//                Debt = debt,
//                Recipients = new List<User> { debt.Student }
//            };
//            if (debt.Student.Guardians?.Any() == true)
//            {
//                notification.Recipients.AddRange(debt.Student.Guardians);
//            }
//            _context.DebtsNotification.Add(notification);
//            await _context.SaveChangesAsync();
//        }
//        public async Task SendPaymentConfirmation(Payment payment)
//        {
//            var notification = new DebtNotification
//            {
//                Title = "Payment Received",
//                Message = $"Payment of {payment.Amount:C} has been processed",
//                CreatedDate= DateTime.Now,
//                Type = NotificationType.PaymentReceived,
//                Debt = payment.Debt,
//                Recipients = new List<User> { payment.Debt.Student, payment.PaidBy}
//            };
//            _context.DebtsNotification.Add(notification);
//            await _context.SaveChangesAsync();
//        }
//        public async Task SendLateFeeNotification(Debt debt, decimal feeAmount)
//        {
//            var notification = new DebtNotification
//            {
//                Title = "Late Fee Applied",
//                Message = $"A late fee of {feeAmount:C} has been applied to your debt",
//                CreatedDate = DateTime.Now,
//                Type = NotificationType.PaymentOverdue,
//                Debt = debt,
//                Recipients = new List<User> { debt.Student }
//            };
//            if (debt.Student.Guardians?.Any() == true)
//            {
//                notification.Recipients.AddRange(debt.Student.Guardians);
//            }
//            _context.DebtsNotification.Add(notification);
//            await _context.SaveChangesAsync();
//        }

//        public async Task SendInterestAppliedNotification(Debt debt, decimal interestAmount)
//        {
//            var notification = new DebtNotification
//            {
//                Title = "Interest Applied",
//                Message = $"Interest of {interestAmount:C} has been applied to your debt",
//                CreatedDate = DateTime.Now,
//                Type = NotificationType.DebtUpdated,
//                Debt = debt,
//                Recipients = new List<User> { debt.Student }
//            };

//            _context.DebtsNotification.Add(notification);
//            await _context.SaveChangesAsync();
//        }

//    }
//}
