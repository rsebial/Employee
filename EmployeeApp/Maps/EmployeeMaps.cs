using EmployeeApp.Api.Dto;
using EmployeeApp.Domain.Commands;
using EmployeeApp.Domain.Models;
using EmployeeApp.Domain.Queries;
using Mapster;

namespace EmployeeApp.Api.Maps;

// defines maps between the model and dto's and the dto's and commands
public class EmployeeMaps : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // queries
        config.NewConfig<EmployeeQueryDto, EmployeeSearch.Query>();

        // model
        config.NewConfig<Employee, EmployeeSearchDto>();

        // commands
        config.NewConfig<EmployeeCreateDto, EmployeeCreate.Command>();
        config.NewConfig<EmployeeUpdateDto, EmployeeUpdate.Command>();
    }
}

