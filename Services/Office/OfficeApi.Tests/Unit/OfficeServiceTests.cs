using Moq;
using OfficeApi.Application.DTOs;
using OfficeApi.Application.Interfaces;
using OfficeApi.Application.Services;
using OfficeApi.Domain.Entities;
using OfficeApi.Domain.Enums;

namespace OfficeApi.Tests.Unit;

public class OfficeServiceTests
{
    [Fact]
    public async Task CreateAsync_ShouldCreateActiveOffice()
    {
        // Arrange
        var repository = new Mock<IOfficeRepository>();
        var service = new OfficeService(repository.Object);
        var request = new CreateOfficeRequest
        {
            City = "Minsk",
            Street = "Lenina",
            HouseNumber = "10",
            OfficeNumber = "5",
            RegistryPhoneNumber = "+375291234567"
        };
        // Act
        var result = await service.CreateAsync(request);
        // Assert
        Assert.NotEqual(Guid.Empty, result.Id);
        Assert.Equal("Minsk, Lenina, 10, office 5", result.Address);
        Assert.Equal(OfficeStatus.Active, result.Status);
        repository.Verify(
            x => x.AddAsync(It.Is<Office>(office =>
                office.Id == result.Id &&
                office.City == "Minsk" &&
                office.Status == OfficeStatus.Active)),
            Times.Once);
    }

    [Fact]
    public async Task ChangeStatusAsync_ShouldUpdateExistingOffice()
    {
        // Arrange
        var officeId = Guid.NewGuid();
        var office = new Office
        {
            Id = officeId,
            City = "Minsk",
            Street = "Lenina",
            HouseNumber = "10",
            RegistryPhoneNumber = "+375291234567",
            Status = OfficeStatus.Active
        };
        var repository = new Mock<IOfficeRepository>();
        repository
            .Setup(x => x.GetByIdAsync(officeId))
            .ReturnsAsync(office);
        var service = new OfficeService(repository.Object);
        var request = new ChangeOfficeStatusRequest
        {
            Status = OfficeStatus.Inactive
        };
        // Act
        var result = await service.ChangeStatusAsync(officeId, request);
        // Assert
        Assert.NotNull(result);
        Assert.Equal(OfficeStatus.Inactive, result.Status);
        Assert.Equal(OfficeStatus.Inactive, office.Status);
        repository.Verify(
            x => x.UpdateAsync(office),
            Times.Once);
    }

    [Fact]
    public async Task ChangeStatusAsync_ShouldReturnNull_WhenOfficeDoesNotExist()
    {
        // Arrange
        var officeId = Guid.NewGuid();
        var repository = new Mock<IOfficeRepository>();
        repository
            .Setup(x => x.GetByIdAsync(officeId))
            .ReturnsAsync((Office?)null);
        var service = new OfficeService(repository.Object);
        var request = new ChangeOfficeStatusRequest
        {
            Status = OfficeStatus.Inactive
        };
        // Act
        var result = await service.ChangeStatusAsync(officeId, request);
        // Assert
        Assert.Null(result);
        repository.Verify(
            x => x.UpdateAsync(It.IsAny<Office>()),
            Times.Never);
    }
}
