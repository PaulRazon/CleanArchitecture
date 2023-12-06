

using CleanArchitecture.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
            new ApplicationUser
            {
                Id = "3416fc72-c8ed-41c5-84e2-816a07006d69",
                Email = "admin@localhost.com",
                NormalizedEmail = "admin@localhost.com",
                UserName = "PaulDeus",
                Apellidos = "Razon",
                Nombre = "Paul",
                NormalizedUserName = "PaulDeus",
                PasswordHash = hasher.HashPassword(null, "pauldeus1234"),
                EmailConfirmed = true
            },
            new ApplicationUser
            {
                Id = "7f293740-3841-45ed-98d3-4acd8b8d35c4",
                Email = "juanperez@localhost.com",
                NormalizedEmail = "juanperez@localhost.com",
                UserName = "JuanPerez",
                Apellidos = "Perez",
                Nombre = "Juan",
                NormalizedUserName = "JuanPerez",
                PasswordHash = hasher.HashPassword(null, "pauldeus1234"),
                EmailConfirmed = true
            }
            );
        }
    }
}
