using OfficeApi.Application.Interfaces;
using OfficeApi.Application.DTOs;
using OfficeApi.Domain.Entities;

namespace OfficeApi.Application.Services;

public class OfficeService
{
    // юзаем возможность работать с офисами в хранилище
    private readonly IOfficeRepository _officeRepository;
    
    public OfficeService(IOfficeRepository officeRepository)
    {
        _officeRepository = officeRepository;
    }

    // получаем список офисов и подготоваливаем его к ответу апи
    public async Task<List<OfficeResponse>> GetAllAsync()
    {
        // идем в БД и возвращаем список офисов
        var office = await _officeRepository.GetAllAsync();
        
        // для каждого офиса подготавливаем поля, которые клиент должен получить
        return office.Select(office => new OfficeResponse
        {
            Id = office.Id,
            PhotoUrl = office.PhotoUrl,
            Address = office.Address, 
            Status = office.Status,
            RegistryPhoneNumber = office.RegistryPhoneNumber
        }).ToList();
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
            Status = request.Status,
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
}