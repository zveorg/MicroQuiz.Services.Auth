using MicroQuiz.Services.Auth.Core.Nodels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MicroQuiz.Services.Auth.Infrastructure.EntityFramework
{
    class IdentityDbSeeder
    {
        public static void Seed(ModelBuilder builder)
        {
            PasswordHasher<ApplicationUser> hasher = new PasswordHasher<ApplicationUser>();

            var admin = new ApplicationUser
            {
                UserName = "admin",
                NormalizedUserName = "admin".ToLower(),
                TwoFactorEnabled = false,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            var adminReadOnly = new ApplicationUser
            {
                UserName = "adminro",
                NormalizedUserName = "adminro".ToLower(),
                TwoFactorEnabled = false,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            admin.PasswordHash = hasher.HashPassword(admin, "admin!");
            adminReadOnly.PasswordHash = hasher.HashPassword(adminReadOnly, "adminro");

            var adminRole = new IdentityRole { Name = "Admin", NormalizedName = "admin" };
            var adminReadOnlyRole = new IdentityRole { Name = "AdminReadOnly", NormalizedName = "adminreadonly" };

            builder.Entity<IdentityRole>().HasData(
                adminRole,
                adminReadOnlyRole,
                new IdentityRole { Name = "User", NormalizedName = "user" }
            );
            builder.Entity<ApplicationUser>().HasData(
                admin,
                adminReadOnly
            );

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = adminRole.Id,
                    UserId = admin.Id
                },
                new IdentityUserRole<string>
                {
                    RoleId = adminReadOnlyRole.Id,
                    UserId = adminReadOnly.Id
                }
            );
        }
    }
}
