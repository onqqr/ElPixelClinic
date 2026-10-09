using OfficeApi.Application.Interfaces;
using OfficeApi.Application.DTOs;
using OfficeApi.Domain.Entities;

namespace OfficeApi.Application.Services;

public class OfficeService
{
    private readonly IOfficeRepository _officeRepository;
    
    public OfficeService(IOfficeRepository officeRepository)
    {
        _officeRepository = officeRepository;
    }
    public async Task<List<OfficeResponse>> GetAllAsync()
    {
        var office = await _officeRepository.GetAllAsync();
        return office.Select(office => new OfficeResponse
        {
            Id = office.Id,
            PhotoUrl = office.PhotoUrl,
            Address = office.Address, 
            Status = office.Status,
            RegistryPhoneNumber = office.RegistryPhoneNumber
        }).ToList();
    }

    public async Task<OfficeResponse?> GetByIdAsync(Guid id)
    {
        var office = await _officeRepository.GetByIdAsync(id);
        if (office is null)
        {
            return null;
        }

        return new OfficeResponse
        {
            Id = office.Id,
            PhotoUrl = office.PhotoUrl,
            Address = office.Address,
            Status = office.Status,
            RegistryPhoneNumber = office.RegistryPhoneNumber
        };
    }

    public async Task<OfficeResponse> CreateAsync(CreateOfficeRequest request)
    {
        var office = new Office
        {
            Id = Guid.NewGuid(),
            PhotoUrl = request.PhotoUrl,
            City = request.City,
            Street = request.Street,
            HouseNumber = request.HouseNumber,
            OfficeNumber = request.OfficeNumber,
            RegistryPhoneNumber = request.RegistryPhoneNumber,
        };
        
        await _officeRepository.AddAsync(office);
        return new OfficeResponse
        {
            Id = office.Id,
            PhotoUrl = office.PhotoUrl,
            Address = office.Address,
            Status = office.Status,
            RegistryPhoneNumber = office.RegistryPhoneNumber
        };
    }

    public async Task<OfficeResponse?> ChangeStatusAsync(
        Guid id,
        ChangeOfficeStatusRequest request)
    {
        var office = await _officeRepository.GetByIdAsync(id);
        if (office is null)
        {
            return null;
        }

        office.Status = request.Status;
        await _officeRepository.UpdateAsync(office);

        return new OfficeResponse
        {
            Id = office.Id,
            PhotoUrl = office.PhotoUrl,
            Address = office.Address,
            Status = office.Status,
            RegistryPhoneNumber = office.RegistryPhoneNumber
        };
    }
}