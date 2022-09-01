using EmployeeApp.Domain.Models;

namespace EmployeeApp.Domain.Queries.Filters;

/// <summary>
/// Builder pattern implementation for easy where clauses
/// Methods have simple implementation, and only 1 where if the variable has a query    
/// </summary>
internal static class EmployeeFilters
{   
    public static IQueryable<Employee> WhereFirstName(this IQueryable<Employee> query, string? firstName)
    {
        if(!string.IsNullOrWhiteSpace(firstName)) // condition to add the where
        {
            query = query.Where(x => x.FirstName.StartsWith(firstName)); // add where clause
        }

        return query; // single exit point
    }

    public static IQueryable<Employee> WhereLastName(this IQueryable<Employee> query, string? lastName)
    {
        if (!string.IsNullOrWhiteSpace(lastName)) // condition to add the where
        {
            query = query.Where(x => x.LastName.StartsWith(lastName)); // add where clause
        }

        return query; // single exit point
    }

    public static IQueryable<Employee> WhereTemperatureRange(this IQueryable<Employee> query, double? tempFrom, double? tempTo)
    {
        if (tempFrom >= 0 && tempTo > 0)
        {
            query = query.Where(x => x.Temperature >= tempFrom && x.Temperature <= tempTo);
        }

        return query;
    }

    public static IQueryable<Employee> WhereRecordDateRange(this IQueryable<Employee> query, DateTime? dateFrom, DateTime? dateTo)
    {
        if (dateFrom >= DateTime.MinValue && dateTo > DateTime.MinValue)
        {
            query = query.Where(x => x.RecordDate >= dateFrom && x.RecordDate <= dateTo);
        }

        return query;
    }

    public static IQueryable<Employee> WhereEmployeeNumber(this IQueryable<Employee> query, long? employeeNumber)
    {
        if (employeeNumber > 0)
        {
            query = query.Where(x => x.EmployeeNumber == employeeNumber);
        }

        return query;
    }
}
