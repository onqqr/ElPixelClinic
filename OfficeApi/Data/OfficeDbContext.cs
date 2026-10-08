using Microsoft.EntityFrameworkCore;
using OfficeApi.Models;

namespace OfficeApi.Data;

// сущность, которую нужно хранить в БД
public class OfficeDbContext : DbContext
{
    public OfficeDbContext(DbContextOptions<OfficeDbContext> options)
        : base(options)
    {
    }
    
    // связь Office > DbSet<Office> > таблица Offices
    public DbSet<Office>  Offices { get; set; }
}