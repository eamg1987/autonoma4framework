using autonoma3Tiempo.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Json;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TemperaturaDbContext>(options =>
    options.UseMySQL(connectionString));


var app = builder.Build();
try
{
    Console.WriteLine("hola se ejcuto1");

    string json_original = "https://api.tutiempo.net/json/?lan=es&apid=zxEq44aqz44t3k9&lid=56608";  // Ruta al archivo JSON
    string json = GetHttp(json_original);
    Console.WriteLine("hola se ejcuto2");

    WeatherData weatherData = JsonSerializer.Deserialize<WeatherData>(json);
    Console.WriteLine("hola se ejcuto3");

    Console.WriteLine($"Copy right: {weatherData.copyright}");
    Console.WriteLine($"Dia 1: {weatherData.day1.date}");
    Console.WriteLine($"name: {weatherData.locality.name}");
    Console.WriteLine($"Temperatura: {weatherData.information.temperature}");
    Console.WriteLine($"Hora: {weatherData.hour_hour["hour1"].date}");
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<TemperaturaDbContext>();

    // Consulta utilizando LINQ
            var nuevaTemperatura = new temperatura
        {
            pais = weatherData.locality.country,  // Puedes ajustar esto según tu modelo
            ciudad= weatherData.locality.name,
            fecha= weatherData.day1.date,
            temperatura_max= weatherData.day1.temperature_max,
            temperatura_min= weatherData.day1.temperature_min,
            hora= weatherData.day1.sunset,
            // Otros campos de tu entidad...
        };

        dbContext.temperatura.Add(nuevaTemperatura);
        dbContext.SaveChanges();
    

    var entidades = dbContext.temperatura
         .ToList();

    foreach (var entidad in entidades)
    {
        Console.WriteLine($"Id: {entidad.id_temperatura}");
        Console.WriteLine($"Pais: {entidad.pais}");
        Console.WriteLine($"Ciudad: {entidad.ciudad}");
        Console.WriteLine($"Temperatura Maxima: {entidad.temperatura_max}");
        Console.WriteLine($"Temperatura Minima: {entidad.temperatura_min}");
        Console.WriteLine($"Fecha: {entidad.fecha}");
    }





}
catch (Exception ex)
{
    Console.WriteLine($"Error al realizar la consulta: {ex.Message}");
}
// Configure the HTTP request pipeline.

static string GetHttp(string url)
{
    WebRequest oRequest = WebRequest.Create(url);
    WebResponse oResponse = oRequest.GetResponse();
    Console.WriteLine("hola se ejcuto7");

    using (StreamReader sr = new StreamReader(oResponse.GetResponseStream()))
    {
        Console.WriteLine("hola se ejcuto4");
        Console.WriteLine(sr);

        return sr.ReadToEnd().Trim();
    }
}
app.Run();
