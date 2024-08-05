using ExpenseTraackPro.Domain.Entities;
using ExpenseTrackPro.Application.Interfaces;
using ExpenseTrackPro.Application.Profiles;
using ExpenseTrackPro.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseTrackPro.Application;

public static class ServiceExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        //register services
        services.AddAutoMapper(typeof(MappingProfile));
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IAccountService, AccountService>();
    }
}