using Microsoft.EntityFrameworkCore;
using OfficeApi.Domain.Entities;

namespace OfficeApi.Data;

public class OfficeDbContext : DbContext
{
    public OfficeDbContext(DbContextOptions<OfficeDbContext> options)
        : base(options)
    {
    }

    public DbSet<Office> Offices { get; set; }
}
