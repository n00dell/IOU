﻿// <auto-generated />
using System;
using IOU.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IOU.API.Migrations
{
    [DbContext(typeof(IOUContext))]
    partial class IOUContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IOU.API.Models.Debt", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("AccumulatedInterest")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("AccumulatedLateFees")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CalculationPeriod")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateIssued")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("GracePeriodDays")
                        .HasColumnType("int");

                    b.Property<decimal>("InterestRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("InterestType")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastInterestCalculationDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("LateFeeAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("LateFeePercentage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("LateFeeType")
                        .HasColumnType("int");

                    b.Property<string>("LenderId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("RemainingAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("StudentId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("LenderId");

                    b.HasIndex("StudentId");

                    b.ToTable("Debts");
                });

            modelBuilder.Entity("IOU.API.Models.DebtNotification", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DebtId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ReadDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DebtId");

                    b.ToTable("DebtsNotification");
                });

            modelBuilder.Entity("IOU.API.Models.InterestLog", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CalculationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DaysCounted")
                        .HasColumnType("int");

                    b.Property<string>("DebtId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("InterestAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("InterestRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PrincipalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("DebtId");

                    b.ToTable("InterestLog");
                });

            modelBuilder.Entity("IOU.API.Models.LateFeeLog", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("AssessmentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DaysLate")
                        .HasColumnType("int");

                    b.Property<string>("DebtId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("FeeAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DebtId");

                    b.ToTable("LateFeeLog");
                });

            modelBuilder.Entity("IOU.API.Models.Payment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("DebtId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("InterestPortion")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("LateFeePortion")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PaidById")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("int");

                    b.Property<decimal>("PrincipalPortion")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("TransactionReference")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DebtId");

                    b.HasIndex("PaidById");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("IOU.API.Models.PaymentSchedule", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CompletedInstallments")
                        .HasColumnType("int");

                    b.Property<string>("DebtId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Frequency")
                        .HasColumnType("int");

                    b.Property<decimal>("InstallmentAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TotalInstallments")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DebtId")
                        .IsUnique();

                    b.ToTable("PaymentsSchedule");
                });

            modelBuilder.Entity("IOU.API.Models.ScheduledPayment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<string>("PaymentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ScheduleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PaymentId")
                        .IsUnique();

                    b.HasIndex("ScheduleId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("IOU.API.Models.StudentGuardian", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GuardianId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("GuardianId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentGuardian");
                });

            modelBuilder.Entity("IOU.API.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DebtNotificationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DebtNotificationId");

                    b.ToTable("Users");

                    b.HasDiscriminator<int>("UserType").HasValue(3);

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("IOU.API.Models.Guardian", b =>
                {
                    b.HasBaseType("IOU.API.Models.User");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("IOU.API.Models.Lender", b =>
                {
                    b.HasBaseType("IOU.API.Models.User");

                    b.Property<string>("BusinessRegistrationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("IOU.API.Models.Student", b =>
                {
                    b.HasBaseType("IOU.API.Models.User");

                    b.Property<DateTime>("ExpectedGraduationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("GuardianId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("University")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("GuardianId");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("IOU.API.Models.Debt", b =>
                {
                    b.HasOne("IOU.API.Models.Lender", "Lender")
                        .WithMany("IssuedDebts")
                        .HasForeignKey("LenderId");

                    b.HasOne("IOU.API.Models.Student", "Student")
                        .WithMany("Debts")
                        .HasForeignKey("StudentId");

                    b.Navigation("Lender");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("IOU.API.Models.DebtNotification", b =>
                {
                    b.HasOne("IOU.API.Models.Debt", "Debt")
                        .WithMany("Notifications")
                        .HasForeignKey("DebtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Debt");
                });

            modelBuilder.Entity("IOU.API.Models.InterestLog", b =>
                {
                    b.HasOne("IOU.API.Models.Debt", "Debt")
                        .WithMany("InterestLogs")
                        .HasForeignKey("DebtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Debt");
                });

            modelBuilder.Entity("IOU.API.Models.LateFeeLog", b =>
                {
                    b.HasOne("IOU.API.Models.Debt", "Debt")
                        .WithMany("FeeLogs")
                        .HasForeignKey("DebtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Debt");
                });

            modelBuilder.Entity("IOU.API.Models.Payment", b =>
                {
                    b.HasOne("IOU.API.Models.Debt", "Debt")
                        .WithMany("Payments")
                        .HasForeignKey("DebtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IOU.API.Models.User", "PaidBy")
                        .WithMany()
                        .HasForeignKey("PaidById");

                    b.Navigation("Debt");

                    b.Navigation("PaidBy");
                });

            modelBuilder.Entity("IOU.API.Models.PaymentSchedule", b =>
                {
                    b.HasOne("IOU.API.Models.Debt", "Debt")
                        .WithOne("PaymentSchedule")
                        .HasForeignKey("IOU.API.Models.PaymentSchedule", "DebtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Debt");
                });

            modelBuilder.Entity("IOU.API.Models.ScheduledPayment", b =>
                {
                    b.HasOne("IOU.API.Models.Payment", "Payment")
                        .WithOne()
                        .HasForeignKey("IOU.API.Models.ScheduledPayment", "PaymentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("IOU.API.Models.PaymentSchedule", "Schedule")
                        .WithMany("ScheduledPayments")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Payment");

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("IOU.API.Models.StudentGuardian", b =>
                {
                    b.HasOne("IOU.API.Models.Guardian", "Guardian")
                        .WithMany("StudentGuardian")
                        .HasForeignKey("GuardianId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("IOU.API.Models.Student", "Student")
                        .WithMany("StudentGuardians")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guardian");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("IOU.API.Models.User", b =>
                {
                    b.HasOne("IOU.API.Models.DebtNotification", null)
                        .WithMany("Recipients")
                        .HasForeignKey("DebtNotificationId");
                });

            modelBuilder.Entity("IOU.API.Models.Student", b =>
                {
                    b.HasOne("IOU.API.Models.Guardian", null)
                        .WithMany("Students")
                        .HasForeignKey("GuardianId");
                });

            modelBuilder.Entity("IOU.API.Models.Debt", b =>
                {
                    b.Navigation("FeeLogs");

                    b.Navigation("InterestLogs");

                    b.Navigation("Notifications");

                    b.Navigation("PaymentSchedule")
                        .IsRequired();

                    b.Navigation("Payments");
                });

            modelBuilder.Entity("IOU.API.Models.DebtNotification", b =>
                {
                    b.Navigation("Recipients");
                });

            modelBuilder.Entity("IOU.API.Models.PaymentSchedule", b =>
                {
                    b.Navigation("ScheduledPayments");
                });

            modelBuilder.Entity("IOU.API.Models.Guardian", b =>
                {
                    b.Navigation("StudentGuardian");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("IOU.API.Models.Lender", b =>
                {
                    b.Navigation("IssuedDebts");
                });

            modelBuilder.Entity("IOU.API.Models.Student", b =>
                {
                    b.Navigation("Debts");

                    b.Navigation("StudentGuardians");
                });
#pragma warning restore 612, 618
        }
    }
}
