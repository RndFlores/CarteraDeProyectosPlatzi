var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();//despues del build se agrega un middleware

// Configure the HTTP request pipeline.
//CADA "UseSwagger, UseSwaggerUI, UseHttpsRedirection, Use.. -> es un Middleware"
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();// para seguridad, de quien puede o no utilizarla.

app. UseWelcomePage();// nos debe mostrar un mensaje de bienvenida que habla sobre la base de la API

app.UseAuthorization();

app.MapControllers();

app.Run();
