using DomainModel;
using Task_Dj;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<DJSettings>(
    builder.Configuration.GetSection("AppDisplaySettings"));

builder.Services.AddSingleton<IDJRepository, DJRepository>();
builder.Services.AddHttpClient<IDJRepository, DJRepository>();
builder.Services.AddSingleton<InMemoryDJRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
 app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/dj", (IDJRepository repository) =>
{
    return repository.GetAllDJs();
});


app.MapGet("/api/dj/{id}", (int id, IDJRepository repository) =>
{
    var dj = repository.GetDJById(id);
    return dj != null ? Results.Ok(dj) : Results.NotFound();
});

app.MapGet("/api/dj/{id}/tracks", (int id, IDJRepository repository) =>
{
    return repository.GetTracksByDJId(id);
});


app.MapPost("/api/dj", (DJ dj, IDJRepository repository) =>
{
    repository.AddDJ(dj);
    return Results.Created($"/api/dj/{dj.Id}", dj);
});

app.Run();
