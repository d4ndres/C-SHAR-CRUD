using _02_learn_entity_framework_core.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// creacion de servicios
//builder.Services.AddDbContext<TareasContext>( p => p.UseInMemoryDatabase("TareasDB"));
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas") );


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbcontexion", async ([FromServices] TareasContext dbContext) => 
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("DataBase in memory <3 " + dbContext.Database.IsInMemory());
});

app.Run();
