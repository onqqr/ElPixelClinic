using OfficeApi.Application;
using OfficeApi.Infrastructure;

// создаем билдер
var builder = WebApplication.CreateBuilder(args);

// регистрируем зависимости 
builder.Services.AddControllers();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

// строим приложение
var app = builder.Build();

// Use.. подключение middleware в pipeline (общение с https)
// app.UseHttpsRedirection();

// подключаем авторизацию, что ASP знал, у кого есть права выполнять операции
app.UseAuthorization();

// собирает и связывает наше приложение с контроллерами (подключаем endpoints)
app.MapControllers();

// запуск приложения
app.Run();