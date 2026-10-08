namespace OfficeApi.Application.DTOs;

using OfficeApi.Domain.Enums;

public class CreateOfficeRequest
{
    public string? PhotoUrl { get; set; }

    public string City { get; set; } = string.Empty;

    public string Street { get; set; } = string.Empty;

    public string HouseNumber { get; set; } = string.Empty;

    public string? OfficeNumber { get; set; }

    public string RegistryPhoneNumber { get; set; } = string.Empty;

    public OfficeStatus Status { get; set; } = OfficeStatus.Active;
}