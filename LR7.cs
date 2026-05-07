// Счётчик для id новых пользователей
int id = 1;

// Список пользователей, с которым будет работать сервер
List<Person> users = new()
{
    new Person { Id = id++, Name = "Tom", Age = 37 },
    new Person { Id = id++, Name = "Bob", Age = 41 },
    new Person { Id = id++, Name = "Sam", Age = 24 }
};

// Создание веб-приложения
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Получение всего списка пользователей
app.MapGet("/api/users", () => users);

// Получение одного пользователя по id
app.MapGet("/api/users/{id}", (int id) =>
{
    var user = users.FirstOrDefault(u => u.Id == id);

    if (user == null)
        return Results.NotFound("Пользователь не найден");

    return Results.Json(user);
});

// Добавление нового пользователя
app.MapPost("/api/users", (Person user) =>
{
    user.Id = id++;      // выдаём новый id
    users.Add(user);     // добавляем в список

    return Results.Json(user);
});

// Изменение пользователя
app.MapPut("/api/users", (Person newUser) =>
{
    var user = users.FirstOrDefault(u => u.Id == newUser.Id);

    if (user == null)
        return Results.NotFound("Пользователь не найден");

    user.Name = newUser.Name;
    user.Age = newUser.Age;

    return Results.Json(user);
});

// Удаление пользователя по id
app.MapDelete("/api/users/{id}", (int id) =>
{
    var user = users.FirstOrDefault(u => u.Id == id);

    if (user == null)
        return Results.NotFound("Пользователь не найден");

    users.Remove(user);

    return Results.Json(user);
});

// Запуск сервера
app.Run();

// Класс пользователя
class Person
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public int Age { get; set; }
}
