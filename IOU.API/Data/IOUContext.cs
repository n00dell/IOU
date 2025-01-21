using IOU.API.Models;
using Microsoft.EntityFrameworkCore;


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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasDiscriminator<UserType>("UserType")
                .HasValue<Student>(UserType.Student)
                .HasValue<Lender>(UserType.Lender)
                .HasValue<User>(UserType.Administrator)
                .HasValue<Guardian>(UserType.Guardian);
            

            modelBuilder.Entity<StudentGuardian>()
                .HasKey(sg => sg.Id);

            modelBuilder.Entity<StudentGuardian>()
                .HasOne(sg => sg.Student)
                .WithMany(s => s.StudentGuardians)
                .HasForeignKey(sg => sg.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
           

            modelBuilder.Entity<StudentGuardian>()
                .HasOne(sg => sg.Guardian)
                .WithMany(g => g.StudentGuardian)
                .HasForeignKey(sg => sg.GuardianId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Debt>()
                .HasOne(d => d.PaymentSchedule)
                .WithOne(ps => ps.Debt)
                .HasForeignKey<PaymentSchedule>(ps => ps.DebtId);

            modelBuilder.Entity<ScheduledPayment>()
                .HasOne(p => p.Schedule)
                .WithMany(ps=> ps.ScheduledPayments)
                .HasForeignKey("ScheduleId")
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ScheduledPayment>()
                .HasOne(p => p.Payment)
                .WithOne()
                .HasForeignKey<ScheduledPayment>("PaymentId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
