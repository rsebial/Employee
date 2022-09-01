using EmployeeApp.Domain.Interfaces;
using EmployeeApp.Domain.Models;
using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EmployeeApp.Domain.Commands;

public static class EmployeeCreate
{
    /// commands are immutable, so record (class) is the best type to use   
    /// commands don't contain model objects, or any other objects, but have to be considered as an instruction to alter the domain
    public record Command(string FirstName, string LastName, double Temperature, DateTime RecordDate) :IRequest<long>;

    public class Handler : IRequestHandler<Command, long>
    {
        public Handler(IUnitOfWork unitOfWork, ILogger<Handler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<Handler> _logger;

        public async Task<long> Handle(Command request, CancellationToken cancellationToken)
        {
            using (_logger.BeginScope($"More Employee will be created : {request.LastName}")) // -- log scope
            {
                using var repository = _unitOfWork.AsyncRepository<Employee>();
                var entity = request.Adapt<Employee>();
                await repository.AddAsync(entity);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                return entity.EmployeeNumber;
            }
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
