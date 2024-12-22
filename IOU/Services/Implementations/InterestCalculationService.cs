//using IOU.Services.Interfaces;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace IOU.Services.Implementations
//{
//    internal class InterestCalculationService: IInterestCalculationService
//    {
//        private readonly ILogger<InterestCalculationService> _logger;
//        private readonly IOUContext _context;
//        public InterestCalculationService(
//            ILogger<InterestCalculationService> logger,
//            IOUContext context)
//        {
//            _logger = logger;
//            _context = context;
//        }
//        public decimal CalculateInterest(Debt debt, DateTime calculationDate)
//        {
//            throw new NotImplementedException();
//        }
//        public decimal ApplyInterest(Debt debt)
//        {
//            throw new NotImplementedException();
//        }
//        public async Task<InterestLog> LogInterestCalculation(Debt debt, decimal interestAmount)
//        {
//            throw new NotImplementedException();
//        }

//        void IInterestCalculationService.ApplyInterest(Debt debt)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
