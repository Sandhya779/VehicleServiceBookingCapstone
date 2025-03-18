using Microsoft.EntityFrameworkCore;
using VehicleServiceBookingApplication.Models;

namespace JWTAuthenticationVehicleServicing.Models
{
    static public class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Roles>().HasData(
                new Roles() { RoleId = 1, RoleType = "Manager" },
                new Roles() { RoleId = 2, RoleType = "Customer" }

                );
            modelBuilder.Entity<ServiceType>().HasData(
                new ServiceType() { ServiceTypeId = 1, ServiceTypeName = "Basic/Interim services" },
                new ServiceType() { ServiceTypeId = 2, ServiceTypeName = " Full/Major services" },
                new ServiceType() { ServiceTypeId = 3, ServiceTypeName = "Specialized Services" }

                );

            modelBuilder.Entity<Status>().HasData(
                new Status() { StatusId = 1, StatusType = "Yet to Start" },
                new Status() { StatusId = 2, StatusType = "In Progress" },
                new Status() { StatusId = 3, StatusType = "Completed" }



               );
            modelBuilder.Entity<User>().HasData(
                new User() { UserId = 1, RoleId = 1, FirstName = "Sravani", LastName = "Chilla", Email = "sravani@gmail.com", Password = "shyam@123" }




               );



        }
    }
}