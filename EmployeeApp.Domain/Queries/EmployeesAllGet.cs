using EmployeeApp.Domain.Interfaces;
using EmployeeApp.Domain.Models;
using MediatR;

namespace EmployeeApp.Domain.Queries;

public static class EmployeesAllGet // static class, containing only other classes
{

    // queries are immutable, so record (class) is the best type to use
    public record Query() : IRequest<IEnumerable<Employee>>;

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
            using var repository = _unitOfWork.AsyncRepository<Employee>();

            var entity = await repository.QueryAsync();
            return entity;
        }
    }
}
