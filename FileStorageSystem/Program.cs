using FileStorageSystem;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

DataBase dataBase = new DataBase();
try
{
    dataBase.DatabaseConnection();
    dataBase.OpenConnection();
}
catch (Exception ex)
{
    Console.WriteLine($"Ошибка выполнения: {ex.Message}");
    Console.WriteLine($"Внутреннее исключение: {ex.InnerException?.Message}");
    Logger.LogError($"User=admin",
                    $"DB connecting error. ", ex);
}
dataBase.CloseConnection();