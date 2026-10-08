using OfficeApi.Domain.Entities;

namespace OfficeApi.Application.Interfaces;

// кто хочет называться репозиторием офисов - должен уметь вернуть список офисов
public interface IOfficeRepository
{
    Task<List<Office>> GetAllAsync();
}