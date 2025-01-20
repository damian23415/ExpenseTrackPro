using ExpenseTraackPro.Domain.Entities;
using ExpenseTraackPro.Domain.Entities.Identity;
using ExpenseTraackPro.Domain.Interfaces;
using ExpenseTrackPro.Infrastructure.Context;
using ExpenseTrackPro.Infrastructure.Repositories;
using ExpenseTrackPro.Infrastructure.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseTrackPro.Infrastructure;

public static class ServiceExtentions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(
            configuration.GetConnectionString("Connection")
        ));

        services.AddIdentityCore<ApplicationUser>()
            .AddRoles<ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddScoped<IRepository<Category>, CategoryRepository>();
                
        //Seeds roles and users
        DefaultRoles.SeedRolesAsync(services.BuildServiceProvider()).Wait();
        DefaultUsers.SeedUsersAsync(services.BuildServiceProvider()).Wait();
    }
}