namespace EmployeeApp.Domain.Models;

/// <summary>
///  simple classes, no methods or logic in here
/// </summary>
public class Employee : EntityBase
{
    public string FirstName { get; set; } =  string.Empty;
    public string LastName { get; set; } = string.Empty;
    public double Temperature { get; set; } = 0.00;
    public DateTime RecordDate { get; set; } = DateTime.Now;
}
