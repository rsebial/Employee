using EmployeeApp.Domain.Interfaces;
using EmployeeApp.Domain.Models;
using EmployeeApp.Domain.Queries.Filters;
using MediatR;

namespace EmployeeApp.Domain.Queries;

public static class EmployeeByFirstNameSearch
{
    public record Query(string? FirstName) : IRequest<IEnumerable<Employee>>;

    // Handler receive specific query and return domain models (or list of domain models)
    public class Handler : IRequestHandler<Query, IEnumerable<Employee>>
    {
        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private readonly IUnitOfWork _unitOfWork;

        public async Task<IEnumerable<Employee>> Handle(Query request, CancellationToken cancellationToken)
        {
            using var repository = _unitOfWork.AsyncRepository<Employee>(); // important : using!

            // construct filter
            var filter = (IQueryable<Employee> q) => q
                .WhereFirstName(request.FirstName);

            // query and return
            var result = await repository.QueryAsync(filter);
            return result;
        }
    }
}
