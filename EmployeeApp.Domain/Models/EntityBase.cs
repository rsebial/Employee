using EmployeeApp.Domain.Interfaces;

namespace EmployeeApp.Domain.Models;

public abstract class EntityBase : IEntity<long>
{
    public long EmployeeNumber { get; set; }
}
