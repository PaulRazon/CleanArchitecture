
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole() { 
                    Id = "61fb637d-99ba-435a-a449-2d6a2fd6fb95",
                    Name = "Administrator",
                    NormalizedName = "administrator",

                },
                new IdentityRole()
                {
                    Id = "ab0df3d2-1d93-454f-ad8a-c23c25cd3616",
                    Name = "operator",
                    NormalizedName = "Operator",

                }
                );
        }
    }
}
