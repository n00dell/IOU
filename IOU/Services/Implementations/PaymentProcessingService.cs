//using MAUI_IOU.Data;
//using MAUI_IOU.Models;
//using MAUI_IOU.Services.Interfaces;
//using Microsoft.Extensions.Logging;
//using Microsoft.ServiceFabric.Services.Communication;
//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Data.Entity.Migrations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MAUI_IOU.Services.Implementations
//{
//    internal class PaymentProcessingService : IPaymentProcessingService
//    {
//        private readonly ILogger<PaymentProcessingService> _logger;
//        private readonly IOUContext _context;
//        private readonly INotificationService _notificationService;

//        public PaymentProcessingService(
//            ILogger<PaymentProcessingService> logger, IOUContext context, INotificationService notificationService)
//        {
//            _logger = logger;
//            _context = context;
//            _notificationService = notificationService;
//        }
//        public async Task<Payment> ProcessPayment(Payment payment)
//        {
//            if (!await ValidatePayment(payment))
//                throw new Common.ServiceException("PaymentProcessingService", "ProcessPayment", "Invalid Payment");

//            AllocatePayment(payment);
//            payment.Status = PaymentStatus.Completed;
//            _context.Payments.Add(payment);

//            var debt = payment.Debt;
//            if (debt.RemainingAmount <= 0)
//            {
//                debt.Status = DebtStatus.Paid;

//            }
//            _context.Debts.Update(debt);
//            await _context.SaveChangesAsync();
            
//            await _notificationService.SendPaymentConfirmation(payment);
//            return payment;
//        }
//        public void AllocatePayment(Payment payment) 
//        {
//            decimal remainingPayment = payment.Amount;
//            if (payment.Debt.AccumulatedLateFees > 0)
//            {
//                payment.LateFeePortion = Math.Min(remainingPayment, payment.Debt.AccumulatedLateFees);
//                remainingPayment -= payment.LateFeePortion;
//                payment.Debt.AccumulatedLateFees -= payment.LateFeePortion;
//            }
//            if(remainingPayment > 0 && payment.Debt.AccumulatedInterest > 0)
//            {
//                payment.InterestPortion = Math.Min(remainingPayment, payment.Debt.AccumulatedInterest);
//                remainingPayment -= payment.InterestPortion;
//                payment.Debt.AccumulatedInterest -= payment.InterestPortion;
//            }
//            payment.PrincipalPortion = remainingPayment;
//            payment.Debt.RemainingAmount -= remainingPayment;
//        }
//        public PaymentSchedule GeneratePaymentSchedule(Payment payment)
//        {
//            var debt = payment.Debt;
//            var schedule = new PaymentSchedule
//            {
//                Debt = debt,
//                Frequency = debt.PaymentSchedule.Frequency,
//                TotalInstallments = CalculateNumberofInstallments(debt),
//                InstallmentAmount = CalculateInstallmentAmount(debt)
//            };
//            var scheduledPayments = new List<ScheduledPayment>();
//            var currentDate = debt.DateIssued;

//            for (int i = 0; i < schedule.TotalInstallments; i++)
//            {
//                var nextPayment = new ScheduledPayment
//                {
//                    Id = Guid.NewGuid().ToString(),
//                    Schedule = schedule,
//                    DueDate = GetNextPaymentDate(currentDate, schedule.Frequency),
//                    Amount = schedule.InstallmentAmount,
//                    IsPaid = false
//                }; 
//                scheduledPayments.Add(nextPayment);
//                currentDate = nextPayment.DueDate;
//            }
//            schedule.ScheduledPayments = scheduledPayments;
//            return schedule;

//        }
//        public async Task<bool> ValidatePayment(Payment payment)
//        {
//            if(payment.Amount <= 0)
//            {
//                return false;
//            }
//            if(payment.Amount > payment.Debt.RemainingAmount)
//            {
//                return false;
//            }
//            return true;
//        }
//        private int CalculateNumberofInstallments(Debt debt)
//        {
//            var totalAmount = debt.RemainingAmount +
//                                                    (debt.InterestType == InterestType.Simple?
//                                                    CalculateSimpleInterest(debt):
//                                                    CalculateCompoundInterest(debt));
//            return (int)Math.Ceiling(totalAmount/CalculateInstallmentAmount(debt));
//        }
//        private decimal CalculateInstallmentAmount(Debt debt)
//        {
//            // Implement your installment calculation logic here
//            // This is a simplified example
//            return debt.RemainingAmount / 12; // Monthly payments over a year
            
//        }
//        private DateTime GetNextPaymentDate(DateTime currentDate, PaymentFrequency frequency)
//        {
//            return frequency switch
//            {
//                PaymentFrequency.Weekly => currentDate.AddDays(7),
//                PaymentFrequency.Biweekly => currentDate.AddDays(14),
//                PaymentFrequency.Monthly => currentDate.AddMonths(1),
//                PaymentFrequency.Quarterly => currentDate.AddMonths(3),
//                PaymentFrequency.Annually => currentDate.AddYears(1),
//                _ => throw new Common.ServiceException("PaymentProcessingService", "GetNextPaymentDate", "Invalid payment frequency")
//            };
//        }
//        private decimal CalculateSimpleInterest(Debt debt)
//        {
//            return debt.RemainingAmount * (debt.InterestRate / 100) * 1;
//        }
//        private decimal CalculateCompoundInterest(Debt debt)
//        {
//            // Implement compound interest calculation
//            return debt.RemainingAmount * (decimal)Math.Pow(1 + (double)(debt.InterestRate / 100), 1) - debt.RemainingAmount;
//        }

        
//    }
//}
