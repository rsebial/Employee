using EmployeeApp.Api.Dto;
using EmployeeApp.Api.Validations.Extensions;
using EmployeeApp.Domain.Commands;
using EmployeeApp.Domain.Queries;
using FluentValidation;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EmployeeApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {        
        public EmployeeController(
            IMediator mediator, 
            ILogger<EmployeeController> logger, 
            IValidator<EmployeeCreateDto> EmployeeCreateValidator,
            IValidator<EmployeeUpdateDto> EmployeeUpdateValidator)
        {
            _mediator = mediator;
            _logger = logger;
            _EmployeeCreateValidator = EmployeeCreateValidator;
            _EmployeeUpdateValidator = EmployeeUpdateValidator;
        }

        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        private readonly IValidator<EmployeeCreateDto> _EmployeeCreateValidator;
        private readonly IValidator<EmployeeUpdateDto> _EmployeeUpdateValidator;

        /// <summary>
        /// Queries for a list of Employees
        /// </summary>
        /// <param name="queryDto"></param>
        /// <returns>Ok</returns>
        [HttpGet("employees")]
        public async Task<IActionResult> QueryAsync([FromQuery] EmployeeQueryDto queryDto)
        {
            try
            {
                var query = queryDto.Adapt<EmployeeSearch.Query>();
                var result = await _mediator.Send(query);
                return Ok(result.Select(x => x.Adapt<EmployeeSearchDto>()));
            }
            catch ( Exception exc)
            {
                _logger.LogError(exc,exc.Message);
                return Problem(exc.Message);
            }
        }

        /// <summary>
        /// Queries for List of Employee by Employee Number
        /// </summary>
        /// <param name="queryDto"></param>
        /// <returns>Ok</returns>
        [HttpGet("employee-number")]
        public async Task<IActionResult> QueryByEmpNumberAsync([FromQuery] EmployeeNumberQueryDto queryDto)
        {
            try
            {
                var query = queryDto.Adapt<EmployeeNumberSearch.Query>();
                var result = await _mediator.Send(query);
                return Ok(result);
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, exc.Message);
                return Problem(exc.Message);
            }
        }


        /// <summary>
        /// Queries for List of Employee by First Name
        /// </summary>
        /// <param name="queryDto"></param>
        /// <returns>Ok</returns>
        [HttpGet("first-name")]
        public async Task<IActionResult> QueryByFirstNameAsync([FromQuery] EmployeeFirstNameQueryDto queryDto)
        {
            try
            {
                var query = queryDto.Adapt<EmployeeByFirstNameSearch.Query>();
                var result = await _mediator.Send(query);
                return Ok(result);
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, exc.Message);
                return Problem(exc.Message);
            }
        }

        /// <summary>
        /// Queries for List of Employee by Last Name
        /// </summary>
        /// <param name="queryDto"></param>
        /// <returns>Ok</returns>
        [HttpGet("last-name")]
        public async Task<IActionResult> QueryByLastNameAsync([FromQuery] EmployeeLastNameQueryDto queryDto)
        {
            try
            {
                var query = queryDto.Adapt<EmployeeByLastNameSearch.Query>();
                var result = await _mediator.Send(query);
                return Ok(result);
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, exc.Message);
                return Problem(exc.Message);
            }
        }

        /// <summary>
        /// Queries for List of Employee by Temperature Range
        /// </summary>
        /// <param name="queryDto"></param>
        /// <returns>Ok</returns>
        [HttpGet("temperature-range")]
        public async Task<IActionResult> QueryByTempRangeAsync([FromQuery] EmployeeTempRangeQueryDto queryDto)
        {
            try
            {
                var query = queryDto.Adapt<EmployeeByTempRangeSearch.Query>();
                var result = await _mediator.Send(query);
                return Ok(result);
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, exc.Message);
                return Problem(exc.Message);
            }
        }

        /// <summary>
        /// Queries for List of Employee by Record Date Range
        /// </summary>
        /// <param name="queryDto"></param>
        /// <returns>Ok</returns>
        [HttpGet("record-date-range")]
        public async Task<IActionResult> QueryByRecordDateRangeAsync([FromQuery] EmployeeRecordDateRangeQueryDto queryDto)
        {
            try
            {
                var query = queryDto.Adapt<EmployeeByRecordDateRangeSearch.Query>();
                var result = await _mediator.Send(query);
                return Ok(result);
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, exc.Message);
                return Problem(exc.Message);
            }
        }


        /// <summary>
        /// Gets single Employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Ok when found, NotFound when not found</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] long id)
        {
            try
            {
                var query = new EmployeeGet.Query(id);
                var result = await _mediator.Send(query);
                if (result != null)
                {
                    return Ok(result.Adapt<EmployeeGetDto>());
                }
                return NotFound();
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, exc.Message);
                return Problem(exc.Message);
            }
        }

        /// <summary>
        /// Gets List of All Employees
        /// </summary>
        /// <param></param>
        /// <returns>Ok when found, NotFound when not found</returns>
        [HttpGet]
        public async Task<IActionResult> GetEmployeesAsync()
        {
            try
            {
                var query = new EmployeesAllGet.Query();
                var result = await _mediator.Send(query);
                if (result != null)
                {
                    return Ok(result.Adapt<EmployeeGetAllDto>());
                }
                return NotFound();
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, exc.Message);
                return Problem(exc.Message);
            }
        }


        /// <summary>
        /// Creates a new Employee
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Created when success, BadRequest when not valid</returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] EmployeeCreateDto? dto)
        {
            try
            {
                if (dto == null) return BadRequest();

                var validationResult = await _EmployeeCreateValidator.ValidateAsync(dto);
                if (validationResult.IsValid)
                {
                    var command = dto.Adapt<EmployeeCreate.Command>();
                    var result = await _mediator.Send(command);
                    return Created(new Uri($"/Employee/{result}", UriKind.Relative), result);
                }
                else
                {
                    validationResult.AddToModelState(this.ModelState);
                    return BadRequest(ModelState);
                }
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, exc.Message);
                return Problem(exc.Message);
            }
        }

        
        /// <summary>
        /// Updates an existing Employee
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Accepted when success, BadRequest when Invalid, NotFound when not found</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] EmployeeUpdateDto? dto)
        {
            try
            {
                if (dto == null) return BadRequest();

                var validationResult = await _EmployeeUpdateValidator.ValidateAsync(dto);
                if (validationResult.IsValid)
                {
                    var command = dto.Adapt<EmployeeUpdate.Command>();
                    var result = await _mediator.Send(command);
                    return result switch
                    {
                        UpdateResult.NotFound => NotFound(),
                        _ => Accepted(new Uri($"/Employee/{dto.EmployeeNumber}", UriKind.Relative), result)
                    };
                } 
                else
                {
                    validationResult.AddToModelState(this.ModelState);
                    return BadRequest(this.ModelState);
                }               
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, exc.Message);
                return Problem(exc.Message);
            }
        }

        /// <summary>
        /// Removes a Employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns>NoContent when success, Forbidden when not allowed</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long id)
        {
            try
            {                
                var result = await _mediator.Send(new EmployeeDelete.Command(id));
                /// Example of return switch statement .NET 6
                return result switch
                {
                    DeleteResult.Forbidden => StatusCode((int)HttpStatusCode.Forbidden),
                    DeleteResult.NotFound => NotFound(),
                    _ => NoContent()
                };

            }
            catch (Exception exc)
            {
                _logger.LogError(exc, exc.Message);
                return Problem(exc.Message);
            }
        }
    }
}