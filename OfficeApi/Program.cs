// создаем билдер
var builder = WebApplication.CreateBuilder(args);

// регистрируем зависимости 
// подключаем контейнер DI с контроллерами, которые будем юзать
builder.Services.AddControllers();

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