using Microsoft.AspNetCore.Identity;

namespace MVCProject.Models
{
    public class IdentitySeedData
    {
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                // Creating roles in the DB
           
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                // Creating users in the DB

                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "librarian@gmail.com";
                string adminUserPassword = "librarian123";
                string normalUserEmail = "student@gmail.com";
                string normalUserPassword = "student123";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);

                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        UserName = adminUserEmail,
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        FirstName = "John",
                        LastName = "Snow",
                        Gender = Gender.Male,
                        DateOfBirth = new DateTime(1975, 03, 16).Date
                    };

                    await userManager.CreateAsync(newAdminUser, adminUserPassword);
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                var normalUser = await userManager.FindByEmailAsync(normalUserEmail);

                if (normalUser == null)
                {
                    var newNormalUser = new ApplicationUser()
                    {
                        UserName = normalUserEmail,
                        Email = normalUserEmail,
                        EmailConfirmed = true,
                        FirstName = "Jan",
                        LastName = "Kowalski",
                        Gender = Gender.Male,
                        DateOfBirth = new DateTime(1998, 04, 17).Date
            };

                    await userManager.CreateAsync(newNormalUser, normalUserPassword);
                    await userManager.AddToRoleAsync(newNormalUser, UserRoles.User);
                }
            }
        }
    }
}
