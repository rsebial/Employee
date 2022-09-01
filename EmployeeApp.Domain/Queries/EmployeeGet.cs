using EmployeeApp.Domain.Interfaces;
using EmployeeApp.Domain.Models;
using MediatR;

namespace EmployeeApp.Domain.Queries;

public static class EmployeeGet // static class, containing only other classes
{
    
    // queries are immutable, so record (class) is the best type to use
    public record Query(long EmployeeNumber) : IRequest<Employee?>;

    // Handler receive specific query and return domain models (or list of domain models)
    public class Handler : IRequestHandler<Query, Employee?>
    {
        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private readonly IUnitOfWork _unitOfWork;

        public async Task<Employee?> Handle(Query request, CancellationToken cancellationToken)
        {
            using var repository = _unitOfWork.AsyncRepository<Employee>();
            var entity = await repository.GetAsync(request.EmployeeNumber);
            return entity;
        }
    }
}
