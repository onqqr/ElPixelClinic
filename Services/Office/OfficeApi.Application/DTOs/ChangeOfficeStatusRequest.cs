namespace OfficeApi.Application.DTOs;

using OfficeApi.Domain.Enums;

public class ChangeOfficeStatusRequest
{
    public OfficeStatus Status { get; set; }
}