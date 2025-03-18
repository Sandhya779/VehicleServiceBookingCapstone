
using Microsoft.EntityFrameworkCore;
using VehicleServiceBookingApplication.Models;

namespace VehicleServiceBookingApplication.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options) { }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<ServiceType> ServiceType { get; set; }
        public DbSet<ServiceBookings> ServiceBookings { get; set; }
        public DbSet<InvoiceDetails> InvoiceDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Roles>().HasData(
                new Roles { RoleId = 1, RoleType = "Manager" },
                new Roles { RoleId = 2, RoleType = "Customer" }
            );
            modelBuilder.Entity<Status>().HasData(
                new Status { StatusId = 1, StatusType = "Yet to Start" },
                new Status { StatusId = 2, StatusType = "In Progress" },
                new Status { StatusId = 3, StatusType = "Completed" }
            );
            modelBuilder.Entity<ServiceType>().HasData(
                new ServiceType { ServiceTypeId = 1, ServiceTypeName = "Basic/Interim Service" },
                new ServiceType { ServiceTypeId = 2, ServiceTypeName = "Full/Major Service" },
                new ServiceType { ServiceTypeId = 3, ServiceTypeName = "Specialized Services" }
            );
            modelBuilder.Entity<ServiceBookings>().Property(sb => sb.BookingDate).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    RoleId = 1,
                    FirstName = "Admin",
                    LastName = "manager",
                    Email = "admin@example.com",
                    Password = "Admin@123"
                },
                new User
                {
                    UserId = 2,
                    RoleId = 1,
                    FirstName = "Admin",
                    LastName = "executive",
                    Email = "executive@example.com",
                    Password = "Exec@238"
                });
            modelBuilder.Entity<ServiceBookings>()
                .HasOne(sb=>sb.Store).
                WithMany().HasForeignKey(sb=>sb.StoreId).
                OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ServiceBookings>()
                .HasOne(sb => sb.User).
                WithMany().HasForeignKey(sb => sb.UserId).
                OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ServiceBookings>()
                .HasOne(sb => sb.ServiceType).
                WithMany().HasForeignKey(sb => sb.ServiceTypeId).
                OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ServiceBookings>()
                .HasOne(sb=>sb.Status)
                .WithMany().HasForeignKey(sb=>sb.StatusId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

       