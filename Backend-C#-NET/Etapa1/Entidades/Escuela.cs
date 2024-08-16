
namespace CoreEscuela.Entidades;
public class Escuela
{
    string nombre;
    public string Nombre
    {
        get { return "Copia: " + nombre; }
        set { this.nombre = value.ToUpper(); }
    }

    public string UniqueId { get; set; } = Guid.NewGuid().ToString();
    public int AñoDeCreacion { get; set; }
    public string Pais { get; set; }
    public string Ciudad { get; set; }
    public TiposEscuela TiposEscuela { get; set; }

    public List<Curso> Cursos { get; set; }
    public Escuela(string nombre, int anhio, string pais, string ciudad) => (Nombre, AñoDeCreacion, Pais, Ciudad) = (nombre, anhio, pais, ciudad);

    public Escuela(string nombre, int anhio, string pais = "Peru", string ciudad = "Lima", TiposEscuela tipo = TiposEscuela.Secundaria)
    {
        (Nombre, AñoDeCreacion, Pais, Ciudad, TiposEscuela) = (nombre, anhio, pais, ciudad, tipo);
    }

    public override string ToString()
    {
        return $"Nombre\"{Nombre}\', Tipo{TiposEscuela}{System.Environment.NewLine} \n AñoDeCreacion{AñoDeCreacion}, [Pais: {Pais}, Ciudad: {Ciudad}]";
    }

}