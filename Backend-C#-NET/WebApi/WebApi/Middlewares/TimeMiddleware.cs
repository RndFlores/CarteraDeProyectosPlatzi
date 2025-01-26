namespace WebApi.Middlewares
{
    public class TimeMiddleware
    {
        readonly RequestDelegate next;// propiedad que ayuda a invocar el middleware que sigue dentro del ciclo.
        public TimeMiddleware(RequestDelegate nextRequest)
        {
            this.next = nextRequest;
        }
        public async Task InvokeAsync(Microsoft.AspNetCore.Http.HttpContext context) // toda la informacion del Request viene en context.
        {
            //SI USAMOS ESTE ORDEN ROMPERÁ NUESTRA ESTRUCTURA JSON DEL GET, PORQUE PRIMERO HACE EL NEXT Y RDESPUES AGREGARÁ LA HORA
            //await next(context);
            ////procesaremos todos los request y el que tenga la propiedad de time le sobreescribimos con la hora actual
            //if (context.Request.Query.Any(p => p.Key == "time"))
            //{
            //    await context.Response.WriteAsync(DateTime.Now.ToShortDateString());
            //}
            if (context.Request.Query.Any(p => p.Key == "time"))
            {
                await context.Response.WriteAsync(DateTime.Now.ToShortDateString());
            }
            await next(context);
            //LO MEJOR ES HACERLO AL REVES, PORQUE ASÍ PORQUE PRIMERO LE AGREGAREMOS LA FECHA Y LUEGO LA EJECUCION DEL MIDDLEWARE
        }

    }
    //ayuda a hacer el use time middleware dentro de la clase program
    public static class TimeMiddlewareExtension
    {
        public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TimeMiddleware>();
        }
    }
}
