using EmployeeApp.Api.Dto;
using FluentValidation;

namespace EmployeeApp.Api.Validations;

public class EmployeeCreateValidator : AbstractValidator<EmployeeCreateDto>
{
    public EmployeeCreateValidator()
    {
        RuleFor(c => c.FirstName).NotEmpty().MaximumLength(50);
        RuleFor(c => c.LastName).NotEmpty().MaximumLength(50);
        RuleFor(c => c.RecordDate).NotEmpty();
    }
}
