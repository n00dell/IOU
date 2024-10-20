using MAUI_IOU.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_IOU.Data
{
    internal class IOUContext: DbContext
    {
        public DbSet<Debt> Debts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<DebtNotification> DebtsNotification { get; set; }
        public DbSet<Guardian> Guardian { get; set; }
        public DbSet<InterestLog> InterestLog { get; set; } 
        public DbSet<LateFeeLog> LateFeeLog { get; set; }
        public DbSet<Lender> Lender { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public DbSet<PaymentSchedule> PaymentsSchedule { get; set; }

        public DbSet<ScheduledPayment> Schedules { get; set; }

        public DbSet<Student> Students { get; set; }
    }
}
