using Microsoft.EntityFrameworkCore;
using OfficeApi.Application.Interfaces;
using OfficeApi.Domain.Entities;
using OfficeApi.Infrastructure.Data;

namespace OfficeApi.Infrastructure.Repositories;

public class OfficeRepository : IOfficeRepository
{
    private readonly OfficeDbContext _context;
    
    public OfficeRepository(OfficeDbContext context)
    {
        _context = context;
    }

    public async Task<List<Office>> GetAllAsync()
    {
        return await _context.Offices.ToListAsync();
    }

    public async Task<Office?> GetByIdAsync(Guid id)
    {
        // найти первый офис, в котором id совпадает с переданным id
        // если не нашел - null
        return await _context.Offices
            .FirstOrDefaultAsync(office => office.Id == id);
    }

    public async Task AddAsync(Office office)
    {
        await _context.Offices.AddAsync(office); // подготавливаем к добавлению
        await _context.SaveChangesAsync(); // сохраняем в БД
    }
}