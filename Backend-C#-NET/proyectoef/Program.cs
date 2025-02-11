
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
    //Antes el resultado era True, porque estaba la bd en memoria, ahora que est� en PostgreSQL debe dar False  
});


app.MapGet("/api/tareas", async ([FromServices] TareasContext dbcontext)=>{
    //deevolvemos la coleccion de tareas
    //return Results.Ok(dbcontext
    //    .Tareas
    //    .Where(t=>t.PrioridadTarea==proyectoef.Models.Prioridad.Baja)//lo de Linq
    //    );
    //return Results.Ok(
    //    dbcontext.Tareas.Include(c => c.categoria).Where(
    //            c => c.PrioridadTarea == proyectoef.Models.Prioridad.Baja
    //        )
    //    );
    return Results.Ok(dbcontext.Tareas.Include(c=>c.categoria));
});
//FromBody indica que en el cuerpo del Request vendra tarea
app.MapPost("/api/tareas", async ([FromServices] TareasContext dbcontext, [FromBody] Tarea tarea) =>
{
    tarea.TareaId=Guid.NewGuid();
    tarea.FechaCreacion=DateTime.UtcNow;

    //primera forma
    await dbcontext.AddAsync(tarea);//agregamos el objeto tarea

    //segunda forma
    //await dbcontext.Tareas.AddAsync(tarea);

    await dbcontext.SaveChangesAsync();//confirmamos que los datos de aca se guarden en la bd
    return Results.Ok("Se guardo con exito la tarea!");
});

app.MapPut("/api/tareas/{id}", async ([FromServices] TareasContext dbcontext, [FromBody] Tarea tarea, [FromRoute] Guid id)=>
{
    var TareaActual = dbcontext.Tareas.Find(id);

    if(TareaActual != null)
    {
        TareaActual.CategoriaId = tarea.CategoriaId;
        TareaActual.Titulo = tarea.Titulo;
        TareaActual.PrioridadTarea = tarea.PrioridadTarea;
        TareaActual.Descripcion=tarea.Descripcion;

        await dbcontext.SaveChangesAsync();
        return Results.Ok();
    }
    return Results.NotFound();
});

app.MapDelete("api/tareas/{id}", async ([FromServices] TareasContext dbcontext, [FromRoute]Guid id) => { 
    var TareaEliminar=dbcontext.Tareas.Find(id);
    if (TareaEliminar != null) {
        dbcontext.Remove(TareaEliminar);
        await dbcontext.SaveChangesAsync();

        return Results.Ok();
    }
    return Results.NotFound("Tarea no encontrada");
});
app.Run();
