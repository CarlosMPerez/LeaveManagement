using LeaveManagement.Common.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Data.Configuration;

public class RoleSeedConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole
            {
                Id = "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                Name = Roles.ADMINISTRATOR,
                NormalizedName = Roles.ADMINISTRATOR.ToUpper()
            },
            new IdentityRole
            {
                Id = "cac43a7e-f7cb-4148-baaf-1abc431eabbf",
                Name = Roles.USER,
                NormalizedName = Roles.USER.ToUpper()
            }
        );
    }
}