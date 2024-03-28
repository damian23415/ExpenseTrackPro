using ExpenseTraackPro.Domain.Entities.Identity;
using ExpenseTrackPro.Application.Interfaces;
using ExpenseTrackPro.Infrastructure.Context;
using ExpenseTrackPro.Infrastructure.Seeds;
using ExpenseTrackPro.Infrastructure.SharedServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseTrackPro.Infrastructure;

public static class ServiceExtentions
{
    public static void AddPersistance(this IServiceCollection services, IConfiguration configuration)
    {
        //register services
        services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(
            configuration.GetConnectionString("Connection")
        ));

        services.AddIdentityCore<ApplicationUser>()
            .AddRoles<ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        services.AddTransient<IAccountService, AccountService>();
        
        //Seeds roles and users
        DefaultRoles.SeedRolesAsync(services.BuildServiceProvider()).Wait();
        DefaultUsers.SeedUsersAsync(services.BuildServiceProvider()).Wait();
    }
}