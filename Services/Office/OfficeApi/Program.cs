using Microsoft.EntityFrameworkCore;
using OfficeApi.Application;
using OfficeApi.Infrastructure;
using OfficeApi.Infrastructure.Data;

// создаем билдер
var builder = WebApplication.CreateBuilder(args);

// регистрируем зависимости 
builder.Services.AddControllers();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

// регистрируем OfficeDbContext - создание и настройка для PostgreSQL
builder.Services.AddDbContext<OfficeDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("OfficeDb")
    ));

// строим приложение
var app = builder.Build();

// Use.. подключение middleware в pipeline (общение с https)
app.UseHttpsRedirection();

// подключаем авторизацию, что ASP знал, у кого есть права выполнять операции
app.UseAuthorization();

// собирает и связывает наше приложение с контроллерами (подключаем endpoints)
app.MapControllers();

// запуск приложения
app.Run();