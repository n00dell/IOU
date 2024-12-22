
//using MAUI_IOU.Data;
//using MAUI_IOU.Models;
//using MAUI_IOU.Services.Interfaces;
//using MAUI_IOU.Services.Common;
//using Microsoft.Extensions.Logging;
//using Microsoft.ServiceFabric.Services.Communication;
//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MAUI_IOU.Services.Implementations
//{
//    internal class LateFeeService :ILateFeeService
//    {
//        private readonly ILogger<LateFeeService> _logger;
//        private readonly IOUContext _context;
//        private readonly INotificationService _notificationService;

//        public LateFeeService(
//            ILogger<LateFeeService> logger, IOUContext context, INotificationService notificationService)
//        {
//            _logger = logger;
//            _context = context;
//            _notificationService = notificationService;
//        }
//        public decimal CalculateLateFee(Debt debt) {
//            if (debt == null)
//                throw new Common.ServiceException(nameof(debt));
//            var daysLate = (DateTime.Now - debt.DueDate).Days;

//            if (daysLate <= debt.GracePeriodDays)
//                return 0;

//            decimal lateFee = debt.LateFeeType switch
//            {
//                LateFeeType.Fixed => debt.LateFeeAmount,
//                LateFeeType.Percentage => debt.RemainingAmount *(debt.LateFeePercentage/ 100),
//                LateFeeType.Both => debt.LateFeeAmount + (debt.RemainingAmount *(debt.LateFeePercentage/100)),
//                _ => throw new Common.ServiceException("LateFeeService","CalculateLateFee", "Invalid late fee type")
//            };
//            return lateFee;
//        }
//        public async Task<LateFeeLog> LogLateFee(Debt debt, decimal feeAmount)
//        {
//            var lateFeeLog = new LateFeeLog
//            {
//                Debt = debt,
//                AssessmentDate = DateTime.Now,
//                FeeAmount = feeAmount,
//                DaysLate = (int)(DateTime.Now - debt.DueDate).TotalDays,
//                Reason = $"Late fee assessed for payment due on {debt.DueDate:d}"
//            };
//            _context.LateFeeLog.Add( lateFeeLog );
//            await _context.SaveChangesAsync();
//            return lateFeeLog;
//        }
//        public async void AssessLateFee(Debt debt)
//        {
//            var latefee = CalculateLateFee(debt);
//            if (latefee > 0)
//            {
//                debt.AccumulatedLateFees += latefee;
//                debt.RemainingAmount += latefee;

//                await LogLateFee(debt, latefee);
//                await _notificationService.SendLateFeeNotification(debt, latefee);

//                _context.Debts.Update(debt);
//                await _context.SaveChangesAsync();
//            }
//        }
//    }
//}
