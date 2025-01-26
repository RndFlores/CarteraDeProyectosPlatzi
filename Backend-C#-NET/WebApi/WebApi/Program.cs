using WebApi.Middlewares;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//INYECCCION DE LA DEPENDENCIA
//normalmente se usa scoped, y la dependencia será HelloworldService, c/ vez que se inyecte IHelloWorldService, se va a 
//crear un nuevo objeto HelloworldService internamente.
//builder.Services.AddScoped<IHelloWorldService,HelloworldService>();


//INYECTAR LA DEPENDENCIA SIN NECESIDAD DE LA INYECCION. Y SOLO USANDO LA CLASE
builder.Services.AddScoped<IHelloWorldService>(p=> new HelloworldService());//especificamos el tipo para que la inyeccion referencia a esta dependencia

var app = builder.Build();//despues del build se agrega un middleware

// Configure the HTTP request pipeline.
//CADA "UseSwagger, UseSwaggerUI, UseHttpsRedirection, Use.. -> es un Middleware"
if (app.Environment.IsDevelopment())//ESTO NO DEBE ESTAR EN PRODUCCION
{
    //estos 2 de abajo configuran Swagger internamente para poder mostrar una pequeña pagina
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();// para seguridad, de quien puede o no utilizarla.

//app. UseWelcomePage();// nos debe mostrar un mensaje de bienvenida que habla sobre la base de la API

app.UseTimeMiddleware();//para usarla ruta sería 'dominioLocal?time'

app.UseAuthorization();

app.MapControllers();

app.Run();
