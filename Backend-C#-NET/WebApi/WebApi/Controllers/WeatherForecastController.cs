using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    //ahora para llamar a la API en la ruta debemos poner 'dominioName/api/controllerName'
    [ApiController]
    [Route("api/[controller]")]//ayuda al enrutamiento del controlador - maneja un nombre dinámico
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        //para que perdure en el tiempo mientras está en memoria
        private static List<WeatherForecast> ListWeatherForecast = new List<WeatherForecast>();
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            if(ListWeatherForecast==null || !ListWeatherForecast.Any())
            {
                ListWeatherForecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
            .ToList();
            }
        }

        //[HttpGet(Name = "GetWeatherForecast")]
        //[Route("Get/weatherforecast")]
        //[Route("Get/weatherforecast2")]
        //[Route("[action]")]//lo vuelve dinámico y hace qeu el nombre de la funcion sea el nombre para la ruta tmb
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return ListWeatherForecast;
        }
        [HttpPost]
        public IActionResult Post(WeatherForecast weatherForecast)
        {
            ListWeatherForecast.Add(weatherForecast);
            return Ok();
        }
        [HttpDelete("{index}")]//va a resivir un index
        public IActionResult Delete(int index)
        {
            try
            {

                ListWeatherForecast.RemoveAt(index);
                return Ok();
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }
    }
}
