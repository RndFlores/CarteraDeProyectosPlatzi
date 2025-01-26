namespace WebApi.Services
{
    public class HelloworldService: IHelloWorldService
    {
        public string GetHelloWorld()
        {
            return "Hellow World!";
        }
    }

    public interface IHelloWorldService
    {
        string GetHelloWorld();

    }
}
