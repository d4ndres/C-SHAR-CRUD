using _02_learn_entity_framework_core.Context;
using _02_learn_entity_framework_core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// creacion de servicios
//builder.Services.AddDbContext<TareasContext>( p => p.UseInMemoryDatabase("TareasDB"));
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas") );


var app = builder.Build();

app.MapGet("/", () => "Hello World!");


// * Despues de dbContex.tabla... podemos agregar metodos para realizar acciones. 
// * Create, Reed, update, delete
// * Tambien podemos filtrar con Where o incluir con filter

// ! GEt:

app.MapGet("/dbcontexion", async ([FromServices] TareasContext dbContext) => 
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("DataBase in memory <3 " + dbContext.Database.IsInMemory());
});

app.MapGet("/api/tareas", async ([FromServices]  TareasContext dbContex )  => 
{
    return Results.Ok(dbContex.Tareas);
});

app.MapGet("/api/categorias", async ([FromServices]  TareasContext dbContex )  => 
{
    return Results.Ok(dbContex.Categorias);
});


app.MapGet("/api/tareas/lowPrio", async ([FromServices]  TareasContext dbContex )  => 
{
    return Results.Ok(dbContex.Tareas.Include( p => p.Categoria ).Where( p => p.PrioridadTarea == _02_learn_entity_framework_core.Models.Prioridad.Baja));
});


// ! POST

app.MapPost("/api/tareas", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea ) =>
{
    tarea.TareaId = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.Now;
    await dbContext.Tareas.AddAsync(tarea);
    await dbContext.SaveChangesAsync();

    return Results.Ok();
});


// ! UPDATE


app.MapPut("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea, [FromRoute] Guid id) =>
{
    var TareaActual = dbContext.Tareas.Find( id );

    if( TareaActual != null )
    {
        TareaActual.CategoriaId = tarea.CategoriaId;
        TareaActual.Titulo = tarea.Titulo;
        TareaActual.PrioridadTarea = tarea.PrioridadTarea;
        TareaActual.Description = tarea.Description;

        await dbContext.SaveChangesAsync();

        return Results.Ok();
    }

    return Results.NotFound();
});

app.MapDelete("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromRoute] Guid id) =>
{
    var tarea = dbContext.Tareas.Find( id );

    if( tarea != null )
    {
        dbContext.Remove(tarea);

        await dbContext.SaveChangesAsync();

        return Results.Ok();
    }

    return Results.NotFound();
});


app.Run();
