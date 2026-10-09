namespace OfficeApi.Tests.Unit;

using OfficeApi.Domain.Entities;
using OfficeApi.Domain.Enums;

public class OfficeTests
{
    [Fact]
    public void Address_ShouldIncludeOfficeNumber()
    {
        // Arrange
        var office = new Office
        {
            City = "Minsk",
            Street = "Lenina",
            HouseNumber = "10",
            OfficeNumber = "5"
        };
        var expectedAddress = "Minsk, Lenina, 10, office 5";
        // Act
        var actualAddress = office.Address;
        // Assert
        Assert.Equal(expectedAddress, actualAddress);
    }

    [Fact]
    public void Address_ShouldNotIncludeOfficeNumber_WhenItIsMissing()
    {
        // Arrange
        var office = new Office
        {
            City = "Minsk",
            Street = "Lenina",
            HouseNumber = "10"
        };
        var expectedAddress = "Minsk, Lenina, 10";
        // Act
        var actualAddress = office.Address;
        // Assert
        Assert.Equal(expectedAddress, actualAddress);
    }

    [Fact]
    public void NewOffice_ShouldHaveActiveStatus()
    {
        // Arrange
        var office = new Office();
        // Act
        var actualStatus = office.Status;
        // Assert
        Assert.Equal(OfficeStatus.Active, actualStatus);
    }
}
