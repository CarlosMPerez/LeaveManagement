using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Data.Configuration;

public class UserSeedConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        var hasher = new PasswordHasher<Employee>();
        builder.HasData(
            new Employee
            {
                Id = "dad43a7e-f3cb-4237-bccf-2abc431baebf",
                Email = "admin@firm.com",
                NormalizedEmail = "ADMIN@FIRM.COM",
                NormalizedUserName = "ADMIN@FIRM.COM",
                UserName = "admin@firm.com",
                FirstName = "System",
                LastName = "Admin",
                PasswordHash = hasher.HashPassword(null, "P4ssw0rd!"),
                EmailConfirmed = true
            },
            new Employee
            {
                Id = "b1b43a7e-d3ba-7324-bddf-2cba431baebf",
                Email = "user@firm.com",
                NormalizedEmail = "USER@FIRM.COM",
                NormalizedUserName = "USER@FIRM.COM",
                UserName = "user@firm.com",
                FirstName = "System",
                LastName = "User",
                PasswordHash = hasher.HashPassword(null, "P4ssw0rd!"),
                EmailConfirmed = true
            }
        ); ;
    }
}