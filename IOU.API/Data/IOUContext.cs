using IOU.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace IOU.API.Data
{
    public class IOUContext : DbContext
    {
        public IOUContext(DbContextOptions<IOUContext> options) : base (options){ }

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
