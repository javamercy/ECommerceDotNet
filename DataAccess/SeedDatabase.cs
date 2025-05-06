using Entities.Concretes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess;

public static class SeedDatabase
{
    public static async Task Initialize(this IApplicationBuilder app)
    {
        var userManager = app.ApplicationServices.CreateScope().ServiceProvider
            .GetRequiredService<UserManager<AppUser>>();
        var roleManager = app.ApplicationServices.CreateScope().ServiceProvider
            .GetRequiredService<RoleManager<AppRole>>();

        if (roleManager.Roles.Any())
        {
            var adminRole = new AppRole { Name = "Admin" };
            var customerRole = new AppRole { Name = "Customer" }; Microsoft.Data.Sqlite.SqliteException: 'SQLite Error 1: 'no such table: AspNetRoles'.'

            await roleManager.CreateAsync(adminRole);
            await roleManager.CreateAsync(customerRole);
        }

        if (userManager.Users.Any())
        {
            var customer = new AppUser()
            {
                FirstName = "Emrecan",
                LastName = "Kurşun",
                UserName = "emre.kursun",
                Email = "emre.kursun@gmail.com"
            };

            var admin = new AppUser()
            {
                FirstName = "Admin",
                LastName = "Admin",
                UserName = "admin",
                Email = "admin.admin@gmail.com"
            };

            var customerResult = await userManager.CreateAsync(customer, "Password123!");
            if (customerResult.Succeeded)
            {
                await userManager.AddToRoleAsync(customer, "Customer");
            }

            var adminResult = await userManager.CreateAsync(admin, "Password123!");
            if (adminResult.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }
}