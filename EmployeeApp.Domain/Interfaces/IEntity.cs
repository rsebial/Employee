namespace EmployeeApp.Domain.Interfaces;
public interface IEntity<TKey>
{
    TKey EmployeeNumber { get; set; }
}
