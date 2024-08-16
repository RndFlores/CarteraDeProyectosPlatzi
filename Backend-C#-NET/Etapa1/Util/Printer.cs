using static System.Console;
namespace CoreEscuela.Entidades;
public class Printer
{
    public static void DibujarTitulo(string titulo = "")
    {
        var tamaño = titulo.Length + 4;
        var linea = "".PadLeft(tamaño, '=');
        WriteLine(linea);
        WriteLine($"| {titulo} |".ToUpper());
        WriteLine(linea);
    }
}