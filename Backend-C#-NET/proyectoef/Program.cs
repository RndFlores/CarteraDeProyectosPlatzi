
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectoef;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TareasContext>(
    p=>p.UseInMemoryDatabase("TareasDB")// funcion de entity framewoek core
    );

var app = builder.Build();//Momento donde se construye la aplicacion y escuchando peticiones

app.MapGet("/", () => "Hello World!");

//creo una bd en memoria exitosamente con la configuracion que tenemos, ahora es el momento de conectarse a una bd de verdad
app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext) =>
{
    dbContext.Database.EnsureCreated();//crea la db
    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
});

app.Run();
