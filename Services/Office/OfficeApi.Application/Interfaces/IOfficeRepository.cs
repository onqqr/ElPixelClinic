using OfficeApi.Domain.Entities;

namespace OfficeApi.Application.Interfaces;

// кто хочет называться репозиторием офисов - должен уметь юзать эти методы
public interface IOfficeRepository
{
    Task<List<Office>> GetAllAsync();
    Task<Office?> GetByIdAsync(Guid id);
    Task AddAsync(Office office);
}