using Application.Enums;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Persistance.Seeds;

public static class DefaultRoles
{
    public static async Task SeedRolesAsync(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

        var superAdmin = new ApplicationRole()
        {
            Name = Roles.SuperAdmin.ToString(),
            NormalizedName = Roles.SuperAdmin.ToString().ToUpper()
        };
        await roleManager.CreateAsync(superAdmin);
        
        var admin = new ApplicationRole()
        {
            Name = Roles.Admin.ToString(),
            NormalizedName = Roles.Admin.ToString().ToUpper()
        };
        await roleManager.CreateAsync(admin);
        
        var basic = new ApplicationRole()
        {
            Name = Roles.Basic.ToString(),
            NormalizedName = Roles.Basic.ToString().ToUpper()
        };
        await roleManager.CreateAsync(basic);
    }
}