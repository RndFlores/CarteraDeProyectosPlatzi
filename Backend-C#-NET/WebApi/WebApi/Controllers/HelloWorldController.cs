using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloWorldController : ControllerBase
    {
        IHelloWorldService helloWorldService;
        public HelloWorldController(IHelloWorldService helloWorldService) { 
            this.helloWorldService = helloWorldService;//RECIBIMOS LA INSTANCIA QUE EL INYECTOR A CREADO
                                                       //Y lo guardamos dentro de la propiedad del controlador
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(helloWorldService.GetHelloWorld());
        }
    }
}
