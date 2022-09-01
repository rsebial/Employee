using EmployeeApp.Api.Dto;
using EmployeeApp.Domain.Commands;
using EmployeeApp.Domain.Models;
using EmployeeApp.Domain.Queries;
using NUnit.Framework;

namespace EmployeeApp.Api.Tests.Maps;

internal class EmployeeMapTests : TestBase
{
    [Test]
    public void Map_QueryDto_To_Query()
    {
        // arrange
        var item = Fixture.Create<EmployeeQueryDto>();

        // act
        var actual = item.Adapt<EmployeeSearch.Query>();

        // assert
        Assert.IsNotNull(actual); 
        Assert.That(actual.FirstName, Is.EqualTo(item.FirstName));
        Assert.That(actual.LastName, Is.EqualTo(item.LastName));
    }

    [Test]
    public void Map_Employee_To_SearchDto()
    {
        // arrange
        var item = Fixture.Create<Employee>();

        // act
        var actual = item.Adapt<EmployeeSearchDto>();

        // assert
        Assert.IsNotNull(actual);
        Assert.That(actual.EmployeeNumber, Is.EqualTo(item.EmployeeNumber));
        Assert.That(actual.FirstName, Is.EqualTo(item.FirstName));
        Assert.That(actual.LastName, Is.EqualTo(item.LastName));        
    }


    [Test]
    public void Map_Employee_To_GetDto()
    {
        // arrange
        var item = Fixture.Create<Employee>();

        // act
        var actual = item.Adapt<EmployeeGetDto>();

        // assert
        Assert.IsNotNull(actual);
        Assert.That(actual.EmployeeNumber, Is.EqualTo(item.EmployeeNumber));
        Assert.That(actual.FirstName, Is.EqualTo(item.FirstName));
        Assert.That(actual.FirstName, Is.EqualTo(item.LastName));
        Assert.That(actual.Temperature, Is.EqualTo(item.Temperature));
        Assert.That(actual.RecordDate, Is.EqualTo(item.RecordDate));
    }

    [Test]
    public void Map_CreateDto_To_Command()
    {
        // arrange
        var item = Fixture.Create<EmployeeCreateDto>();

        // act
        var actual = item.Adapt<EmployeeCreate.Command>();

        // assert
        Assert.IsNotNull(actual);
        Assert.That(actual.FirstName, Is.EqualTo(item.FirstName));
        Assert.That(actual.LastName, Is.EqualTo(item.LastName));
        Assert.That(actual.Temperature, Is.EqualTo(item.Temperature));
        Assert.That(actual.RecordDate, Is.EqualTo(item.RecordDate));
    }

    [Test]
    public void Map_UpdateDto_To_Command()
    {
        // arrange
        var item = Fixture.Create<EmployeeUpdateDto>();

        // act
        var actual = item.Adapt<EmployeeUpdate.Command>();

        // assert
        Assert.IsNotNull(actual);
        Assert.That(actual.EmployeeNumber, Is.EqualTo(item.EmployeeNumber));
        Assert.That(actual.FirstName, Is.EqualTo(item.FirstName));
        Assert.That(actual.LastName, Is.EqualTo(item.LastName));
        Assert.That(actual.Temperature, Is.EqualTo(item.Temperature));
        Assert.That(actual.RecordDate, Is.EqualTo(item.RecordDate));
    }
}
