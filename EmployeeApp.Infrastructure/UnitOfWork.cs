using EmployeeApp.Domain.Interfaces;
using EmployeeApp.Infrastructure.MySQL;

namespace EmployeeApp.Infrastructure;

internal class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(EmployeeContext EmployeeContext)
    {
        _repositories = new List<IRepository>();
        _EmployeeContext = EmployeeContext;
    }

    private readonly IList<IRepository> _repositories;
    private readonly EmployeeContext _EmployeeContext;

    public IAsyncRepository<T> AsyncRepository<T>() 
        where T : class, IEntity<long>
    {
        var repository = new GenericRepository<T>(_EmployeeContext);
        _repositories.Add(repository);
        return repository;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _EmployeeContext.SaveChangesAsync(cancellationToken);
    }
}
