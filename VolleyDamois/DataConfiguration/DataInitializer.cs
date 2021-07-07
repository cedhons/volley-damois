using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace VolleyDamois.DataConfiguration
{
    public static class DataInitializer
    {
        public static async Task SeedDefaultUsers(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await SeedRole(roleManager);
            await SeedUser(userManager);
        }

        private static async Task SeedUser(UserManager<IdentityUser> userManager)
        {
            string[] names = { "bernard@mail.com" , "nicola@mail.com", "marie@mail.com" };
            string password = "Pass123@";
            string role = "Committee";

            foreach (var name in names)
            {
                if (await userManager.FindByNameAsync(name) == null)
                {
                    IdentityUser user = new IdentityUser() { Email = name, UserName = name };
                    var result = await userManager.CreateAsync(user, password);

                    if (result.Succeeded)
                        await userManager.AddToRoleAsync(user, role);
                }
            }
        }

        private static async Task SeedRole(RoleManager<IdentityRole> roleManager)
        {
            string[] names = { "Committee" };

            foreach (var name in names)
            {
                if (! await roleManager.RoleExistsAsync(name))
                {
                    IdentityRole role = new IdentityRole() { Name = name };
                    await roleManager.CreateAsync(role);
                }
            }
        }
    }
}
