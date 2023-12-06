
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "61fb637d-99ba-435a-a449-2d6a2fd6fb95",
                    UserId = "3416fc72-c8ed-41c5-84e2-816a07006d69",

                },
            new IdentityUserRole<string>
            {
                RoleId = "ab0df3d2-1d93-454f-ad8a-c23c25cd3616",
                UserId = "7f293740-3841-45ed-98d3-4acd8b8d35c4",

            });
        }
    }
}
