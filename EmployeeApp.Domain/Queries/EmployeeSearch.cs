using EmployeeApp.Domain.Interfaces;
using EmployeeApp.Domain.Models;
using EmployeeApp.Domain.Queries.Filters;
using MediatR;

namespace EmployeeApp.Domain.Queries;

public static class EmployeeSearch
{
    public record Query(string? FirstName = null, string? LastName = null, double Temperature = 0, DateTime? RecordDate = null) : IRequest<IEnumerable<Employee>>;

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
                .WhereFirstName(request.FirstName)
                .WhereLastName(request.LastName);

            // query and return
            var result = await repository.QueryAsync(filter);
            return result;
        }
    }
}
