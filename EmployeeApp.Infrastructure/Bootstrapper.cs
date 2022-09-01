using EmployeeApp.Domain.Interfaces;
using EmployeeApp.Infrastructure.MySQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeApp.Infrastructure;

public static class Bootstrapper
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IUnitOfWork, UnitOfWork>();

        var connectionString = configuration.GetConnectionString("EmployeeContext");
#if DEBUG
        services.AddDbContext<EmployeeContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
#else
        services.AddDbContext<EmployeeContext>(options => options.UseInMemoryDatabase("EmployeeDb"));
#endif

        return services;
    }
}