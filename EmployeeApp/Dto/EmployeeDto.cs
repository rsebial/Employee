namespace EmployeeApp.Api.Dto;

public record EmployeeSearchDto(long EmployeeNumber, string FirstName, string LastName);
public record EmployeeQueryDto(string? FirstName, string? LastName);
public record EmployeeNumberQueryDto(string? EmployeeNumber);
public record EmployeeFirstNameQueryDto(string? FirstName);
public record EmployeeLastNameQueryDto(string? LastName);
public record EmployeeRecordDateRangeQueryDto(DateTime? DateFrom, DateTime? DateTo);
public record EmployeeTempRangeQueryDto(double? TempFrom, double? TempTo);
public record EmployeeGetDto(long EmployeeNumber, string FirstName, string LastName, double Temperature, DateTime RecordDate);

public record EmployeeGetAllDto(long EmployeeNumber, string FirstName, string LastName, double Temperature, DateTime RecordDate);
public record EmployeeCreateDto(string? FirstName, string? LastName, double? Temperature, DateTime? RecordDate);
public record EmployeeUpdateDto(long EmployeeNumber, string? FirstName, string? LastName, double? Temperature, DateTime? RecordDate);
public record EmployeeDeleteDto(long EmployeeNumber);

