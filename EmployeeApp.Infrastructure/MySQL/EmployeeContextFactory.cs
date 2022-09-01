using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EmployeeApp.Infrastructure.MySQL;

internal class EmployeeContextFactory : IDesignTimeDbContextFactory<EmployeeContext>
{
    public EmployeeContext CreateDbContext(string[] args)
    {
        var optionsbuilder = new DbContextOptionsBuilder<EmployeeContext>();
        var connectionString = "server=localhost;user=Employee_user;password=Employee123;database=EmployeeDb";
        optionsbuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        return new EmployeeContext(optionsbuilder.Options);
    }
}
