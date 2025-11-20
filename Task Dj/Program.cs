using DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Task_Dj;
using Task_Dj.DbContextDj;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<DJSettings>(
    builder.Configuration.GetSection("AppDisplaySettings"));

builder.Services.AddScoped<IDJService, DJRepository>();
builder.Services.AddHttpClient<IDJService, DJRepository>();
builder.Services.AddScoped<IDjInMemoryRepository,InMemoryDJRepository>();

builder.Services.AddDbContext<DJWriteDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddDbContext<DJReadDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
 app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/dj", (IDJService repository) =>
{
    return repository.GetAllDJs();
});


app.MapGet("/api/dj/{id}", (int id, IDJService repository) =>
{
    var dj = repository.GetDJById(id);
    return dj != null ? Results.Ok(dj) : Results.NotFound();
});

app.MapGet("/api/dj/{id}/tracks", (int id, IDJService repository) =>
{
    return repository.GetTracksByDJId(id);
});


app.MapPost("/api/dj", (DJ dj, IDJService repository) =>
{
    repository.AddDJ(dj);
    return Results.Created($"/api/dj/{dj.Id}", dj);
});

app.Run();
