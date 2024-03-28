using ExpenseTraackPro.Domain.Entities.Identity;
using ExpenseTrackPro.Application.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseTrackPro.Infrastructure.Seeds;

public static class DefaultUsers
{
    public static async Task SeedUsersAsync(IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        var user = new ApplicationUser();

        user.UserName = "superadmin";
        user.Email = "superAdmin@gmail.com";
        user.FirstName = "Damian";
        user.LastName = "Radomski";
        user.Gender = "Male";
        user.EmailConfirmed = true;
        user.PhoneNumberConfirmed = true;

        if (userManager.Users.All(x => x.Id != user.Id))
        {
            var result = await userManager.FindByEmailAsync(user.Email);

            if (result == null)
            {
                await userManager.CreateAsync(user, "123@Test");
                await userManager.AddToRoleAsync(user, Roles.SuperAdmin.ToString());
                await userManager.AddToRoleAsync(user, Roles.Admin.ToString());
                await userManager.AddToRoleAsync(user, Roles.Basic.ToString());
            }
        }
    }
}