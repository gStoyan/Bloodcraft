﻿namespace Bloodcraft.Web.Infrastructure.Extensions
{
    using Bloodcraft.Data;
    using Bloodcraft.Data.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System.Threading.Tasks;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<BloodcraftDbContext>().Database.Migrate();

                var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                Task
                    .Run(async () =>
                    {
                        var adminName = WebConstants.AdminRole;
                        var roles = new[]
                        {
                            adminName
                       };

                        foreach (var role in roles)
                        {
                            var roleExists = await roleManager.RoleExistsAsync(adminName);
                            if (!roleExists)
                            {
                                await roleManager.CreateAsync(new IdentityRole
                                {
                                    Name = adminName
                                });
                            }
                        }
                        var adminEmail = "admin@bloodcraft.com";
                        var adminUser = await userManager.FindByEmailAsync(adminEmail);

                        if (adminUser == null)
                        {
                            adminUser = new User
                            {
                                Email = adminEmail,
                                UserName = adminName
                            };

                            await userManager.CreateAsync(adminUser, "password");

                            await userManager.AddToRoleAsync(adminUser, adminName);
                        }
                    })
                   .Wait();
            }
            return app;
        }
    }
}

