using EmployeeApp.Domain.Commands.Base;
using EmployeeApp.Domain.Interfaces;
using EmployeeApp.Domain.Models;
using EmployeeApp.Domain.Queries.Filters;
using MediatR;

namespace EmployeeApp.Domain.Commands;

public static class EmployeeDelete
{
    public record Command(long Id) :IRequest<DeleteResult>;

    public class Handler : DeleteHandlerBase<Employee>, IRequestHandler<Command, DeleteResult>
    {
        public Handler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private readonly IUnitOfWork _unitOfWork;

        public async Task<DeleteResult> Handle(Command request, CancellationToken cancellationToken)
        {
            
            return await base.Handle(request.Id, cancellationToken);
        }

    } 
}
