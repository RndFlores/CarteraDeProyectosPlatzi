
namespace CoreEscuela.Entidades;
public class Alumno
{
    public string Nombre { get; set; }
    public string UniqueId { get; set; }
    public Alumno()
    {
        UniqueId = Guid.NewGuid().ToString();
    }
}