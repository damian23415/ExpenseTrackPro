using ExpenseTraackPro.Domain.Entities.Identity;
using ExpenseTrackPro.Application.Interfaces.IRepository;
using ExpenseTrackPro.Infrastructure.Context;
using ExpenseTrackPro.Infrastructure.Repositories;
using ExpenseTrackPro.Infrastructure.Seeds;
using ExpenseTrackPro.Infrastructure.Services.Implementations;
using ExpenseTrackPro.Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseTrackPro.Infrastructure;

public static class ServiceExtentions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        //register services
        services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(
            configuration.GetConnectionString("Connection")
        ));

        services.AddIdentityCore<ApplicationUser>()
            .AddRoles<ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddTransient<IAccountService, AccountService>();
        
        //repos
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        
        //Seeds roles and users
        DefaultRoles.SeedRolesAsync(services.BuildServiceProvider()).Wait();
        DefaultUsers.SeedUsersAsync(services.BuildServiceProvider()).Wait();
    }
}