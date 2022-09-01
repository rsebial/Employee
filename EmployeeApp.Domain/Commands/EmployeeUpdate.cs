using EmployeeApp.Domain.Commands.Base;
using EmployeeApp.Domain.Interfaces;
using EmployeeApp.Domain.Models;
using Mapster;
using MediatR;

namespace EmployeeApp.Domain.Commands;

public static class EmployeeUpdate
{
    public record Command(long EmployeeNumber, string FirstName, string LastName, double Temperature, DateTime RecordDate) :IRequest<UpdateResult>;

    public class Handler : UpdateHandlerBase<Command, Employee>, IRequestHandler<Command, UpdateResult>
    {
        public Handler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public Task<UpdateResult> Handle(Command request, CancellationToken cancellationToken)
        {
            return base.Handle(request.EmployeeNumber, request, cancellationToken);
        }
    }

    public class Map : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Command, Employee>();
        }
    }
}
