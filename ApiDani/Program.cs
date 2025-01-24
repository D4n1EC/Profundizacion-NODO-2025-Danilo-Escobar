var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

var weatherForecast = new List<WeatherForecast>();

// GET: Obtener un recurso
app.MapGet("/weatherforecast/{index}", (int index) =>
{
    if (index < 0 || index >= weatherForecast.Count)
    {
        return Results.NotFound($"No se encontr� un pron�stico en el �ndice {index}.");
    }
    return Results.Ok(weatherForecast[index]);
});

// POST: Crear un nuevo recurso
app.MapPost("/weatherforecast", (WeatherForecast weather) =>
{
    weatherForecast.Add(weather);
    return Results.Created($"/weatherforecast/{weatherForecast.Count - 1}", weather);
});

// PUT: Actualizar un pron�stico existente
app.MapPut("/weatherforecast/{index}", (int index, WeatherForecast weather) =>
{
    if (index < 0 || index >= weatherForecast.Count)
    {
        return Results.NotFound($"No se puede actualizar. No se encontr� un pron�stico en el �ndice {index}.");
    }

    weatherForecast[index] = weather;
    return Results.Ok(weather);
});

// DELETE: Eliminar un pron�stico
app.MapDelete("/weatherforecast/{index}", (int index) =>
{
    if (index < 0 || index >= weatherForecast.Count)
    {
        return Results.NotFound($"No se encontr� un pron�stico en el �ndice {index}.");
    }

    var removed = weatherForecast[index];
    weatherForecast.RemoveAt(index);
    return Results.Ok(removed);
});

// GET: Obtener todos los pron�sticos
app.MapGet("/weatherforecast", () => weatherForecast)
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
