
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectoef;
using proyectoef.Models;
using proyectoef.Migrations;


var builder = WebApplication.CreateBuilder(args);

//Utiliza la bd en memoria
//builder.Services.AddDbContext<TareasContext>(
//    p=>p.UseInMemoryDatabase("TareasDB")// funcion de entity framewoek core
//    );


//para conectarnos a una base de datos en postgreSQL
builder.Services.AddNpgsql<TareasContext>(builder.Configuration.GetConnectionString("TareasDb"));

var app = builder.Build();//Momento donde se construye la aplicacion y escuchando peticiones

app.MapGet("/", () => "Hello World!");

//creo una bd en memoria exitosamente con la configuracion que tenemos, ahora es el momento de conectarse a una bd de verdad
app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext) =>
{
    dbContext.Database.EnsureCreated();//crea la db
    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
    //Antes el resultado era True, porque estaba la bd en memoria, ahora que está en PostgreSQL debe dar False  
});


app.MapGet("/api/tareas", async ([FromServices] TareasContext dbcontext)=>{
    //deevolvemos la coleccion de tareas
    //return Results.Ok(dbcontext
    //    .Tareas
    //    .Where(t=>t.PrioridadTarea==proyectoef.Models.Prioridad.Baja)//lo de Linq
    //    );
    return Results.Ok(
        dbcontext.Tareas.Include(c => c.categoria).Where(
                c => c.PrioridadTarea == Prioridad.Baja
            )
        );
});


app.Run();
