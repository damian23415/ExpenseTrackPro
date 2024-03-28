using ExpenseTrackPro.Application.Interfaces.IService;
using ExpenseTrackPro.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseTrackPro.Application;

public static class ServiceExtensions
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        //register services
        services.AddScoped<ICategoryService, CategoryService>();
    }
}