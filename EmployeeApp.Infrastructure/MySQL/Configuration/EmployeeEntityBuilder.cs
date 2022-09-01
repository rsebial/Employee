using EmployeeApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeApp.Infrastructure.MySQL.Configuration;

internal class EmployeeEntityTypeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employee");

        builder.HasKey(p => p.EmployeeNumber);
        builder.Property(p => p.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(p => p.LastName).IsRequired().HasMaxLength(50);

        /// We seed the datbase with data
        builder.HasData(
            new Employee { EmployeeNumber = 1, FirstName = "Roosevelt", LastName = "Sebial", Temperature = 36.5, RecordDate = Convert.ToDateTime("2022-08-30") },
            new Employee { EmployeeNumber = 2, FirstName = "Rachel", LastName = "Sebial", Temperature = 36.9, RecordDate = Convert.ToDateTime("2022-09-01") },
            new Employee { EmployeeNumber = 3, FirstName = "Cloe", LastName = "Ferrater", Temperature = 36.2, RecordDate = Convert.ToDateTime("2022-08-30") },
            new Employee { EmployeeNumber = 4, FirstName = "Cleo", LastName = "Sebial", Temperature = 36.7, RecordDate = Convert.ToDateTime("2022-08-31") },
            new Employee { EmployeeNumber = 5, FirstName = "Maria", LastName = "Lourdes", Temperature = 37.0, RecordDate = Convert.ToDateTime("2022-08-31") },
            new Employee { EmployeeNumber = 6, FirstName = "Sara", LastName = "Anna", Temperature = 36.9, RecordDate = Convert.ToDateTime("2022-09-01") },
            new Employee { EmployeeNumber = 7, FirstName = "Mateo", LastName = "Juana", Temperature = 36.5, RecordDate = Convert.ToDateTime("2022-09-01") },
            new Employee { EmployeeNumber = 8, FirstName = "Lyka", LastName = "Gairanod", Temperature = 36.3, RecordDate = Convert.ToDateTime("2022-08-30") },
            new Employee { EmployeeNumber = 9, FirstName = "Marcial", LastName = "Guadalupe", Temperature = 36.4, RecordDate = Convert.ToDateTime("2022-08-30") },
            new Employee { EmployeeNumber = 10, FirstName = "Jose", LastName = "Luna", Temperature = 36.6, RecordDate = Convert.ToDateTime("2022-08-31") },
            new Employee { EmployeeNumber = 11, FirstName = "Mario", LastName = "Lucas", Temperature = 36.7, RecordDate = Convert.ToDateTime("2022-08-30") },
            new Employee { EmployeeNumber = 12, FirstName = "Juan", LastName = "Cruz", Temperature = 36.2, RecordDate = Convert.ToDateTime("2022-09-01") },
            new Employee { EmployeeNumber = 13, FirstName = "Rose", LastName = "Antonio", Temperature = 36.9, RecordDate = Convert.ToDateTime("2022-08-29") },
            new Employee { EmployeeNumber = 14, FirstName = "Kat", LastName = "Lopez", Temperature = 36.8, RecordDate = Convert.ToDateTime("2022-08-28") },
            new Employee { EmployeeNumber = 15, FirstName = "Maria", LastName = "Debora", Temperature = 36.5, RecordDate = Convert.ToDateTime("2022-08-25") }
        );
    }
}
