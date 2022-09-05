using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Data.Configuration;

public class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.HasData(
            new IdentityUserRole<string>
            {
                RoleId = "cac43a6e-f7bb-4448-baaf-1add431ccbbf", // Admin
                UserId = "dad43a7e-f3cb-4237-bccf-2abc431baebf" // Admin
            },
            new IdentityUserRole<string>
            {
                RoleId = "cac43a7e-f7cb-4148-baaf-1abc431eabbf", // User
                UserId = "b1b43a7e-d3ba-7324-bddf-2cba431baebf" // User
            }
        );
    }
}