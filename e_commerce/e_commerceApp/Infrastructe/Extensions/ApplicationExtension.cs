using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace e_commerceApp.Infrastructe.Extensions
{
    public static class ApplicationExtension
    {
        public static async void ConfigureDefaultAdminUser(this IApplicationBuilder app)
        {
            const string adminUser = "Admin";
            const string adminPassword = "Admin+123456";

            UserManager<IdentityUser> userManager = app
            .ApplicationServices
            .CreateScope()
            .ServiceProvider
            .GetRequiredService<UserManager<IdentityUser>>();

            RoleManager<IdentityRole> roleManager = app
            .ApplicationServices
            .CreateAsyncScope()
            .ServiceProvider
            .GetRequiredService<RoleManager<IdentityRole>>();

            IdentityUser user = await userManager.FindByNameAsync(adminUser);

            if (user is null)
            {
                user = new IdentityUser()
                {
                    Email ="uby.dpu2643@hotmail.com",
                    PhoneNumber="052332423",
                    UserName =adminUser
                };
                var result = await userManager.CreateAsync(user,adminPassword);

                if (!result.Succeeded)
                    throw new Exception("Admin user could not created");
                
                var roleResult = await userManager.AddToRolesAsync(user,
                    roleManager
                        .Roles
                        .Select(r =>r.Name)
                     .ToList()
                );    
                if (!roleResult.Succeeded)
                {
                    throw new Exception("System have problems with role defination for admin");
                }
            }

        }
    }
}