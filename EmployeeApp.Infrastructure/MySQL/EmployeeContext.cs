using EmployeeApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EmployeeApp.Infrastructure.MySQL;

internal class EmployeeContext : DbContext
{
    public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
    {

    }

    public DbSet<Employee>? Employee { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    } 
}
