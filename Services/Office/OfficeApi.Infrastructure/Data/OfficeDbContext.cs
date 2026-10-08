using Microsoft.EntityFrameworkCore;
using OfficeApi.Domain.Entities;
namespace OfficeApi.Infrastructure.Data;

// мост между C#-сущностями и PostgreSQL
public class OfficeDbContext : DbContext
{
    public OfficeDbContext(DbContextOptions<OfficeDbContext> options)
        : base(options)
    {
    }

    public DbSet<Office> Offices => Set<Office>();
}