using Microsoft.AspNetCore.Identity;
using MyWebApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.Data
{
    public class DbInitializer
    {
        public static async Task Seed(ApplicationDbContext context,
                                    UserManager<ApplicationUser> userManager,
                                    RoleManager<IdentityRole> roleManager)
        {
            //Create DB if not created yet
            context.Database.EnsureCreated();

            //Check roles existance
            if (!context.Roles.Any())
            {
                var roleadmin = new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "admin"
                };
                //Create Admin role
                await roleManager.CreateAsync(roleadmin);
            }

            if (!context.Users.Any())
            {
                //Create user "user@mail.ru"
                var user = new ApplicationUser
                {
                    Email = "user@mail.ru",
                    UserName = "user@mail.ru"
                };
                await userManager.CreateAsync(user, "123456");

                //Create user "admin@mail.ru"
                var admin = new ApplicationUser
                {
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru"
                };
                await userManager.CreateAsync(admin, "123456");
                //Give Admin role to "admin@mail.ru" user
                admin = await userManager.FindByNameAsync("admin@mail.ru");
                await userManager.AddToRoleAsync(admin, "admin");
            }
        }
    }
}
