using CoreEscuela.Entidades;
using static System.Console;
namespace CoreEscuela;

class Program
{

    private static void ImprimirCursoWhile(List<Curso> arregloCursos)
    {
        int contador = 0;
        while (contador < arregloCursos.Count)
        {
            WriteLine($"Nombre: {arregloCursos[contador].Nombre}, Id: {arregloCursos[contador].UniqueId}");
            contador++;
        }
    }
    private static void ImprimirCursoForEach(IEnumerable<Curso> arregloCursos)
    {

        foreach (var curso in arregloCursos)
        {
            if (curso != null)
            {
                WriteLine($"Nombre: {curso.Nombre}, Id: {curso.UniqueId}");
                foreach (var alumno in curso.Alumnos)
                {
                    WriteLine($"Alumno: {alumno.Nombre}");
                }
                foreach (var asignatura in curso.Asignaturas)
                {
                    WriteLine($"Asignatura: {asignatura.Nombre}");
                }

                foreach (var evaluaciones in curso.Evaluaciones)
                {
                    WriteLine($"Evaluacion: {evaluaciones.Nombre} Nota: {evaluaciones.Nota} Alumno: {evaluaciones.Alumno.Nombre} Asignatura: {evaluaciones.Asignatura.Nombre}");
                }
            }
        }
    }
    private static void ImprimirCursosEscuela(Escuela escuela, string metodo)
    {
        WriteLine("=========================");
        WriteLine("Cursos de Escuela");
        if (escuela?.Cursos == null)
        {
            WriteLine("No se han asignado cursos");
        }
        else
        {
            switch (metodo)
            {
                case "foreach":
                    ImprimirCursoForEach(escuela.Cursos);
                    break;
                case "while":
                    ImprimirCursoWhile(escuela.Cursos);
                    break;
                default:
                    WriteLine("Metodo no soportado");
                    break;
            }
        }
        WriteLine("=========================");
    }
    static void Main(string[] args)
    {
        var engine = new EscuelaEngine();
        engine.Inicializar();

        Printer.DibujarTitulo("Bienvenidos a la Escuela");

        WriteLine(engine.Escuela);

        ImprimirCursosEscuela(engine.Escuela, "foreach");

        var otra_collection = new List<Curso>(){
            new Curso(){
                    Nombre = "Calculo",
                    Jornada = TiposJornada.Mañana
                },
                new Curso(){
                    Nombre = "Dibujo",
                    Jornada = TiposJornada.Tarde
                },
                new Curso(){
                    Nombre = "Biologia",
                    Jornada = TiposJornada.Noche
                }
        };
        engine.Escuela.Cursos.AddRange(otra_collection);//agregamos toda una coleccion

        ImprimirCursosEscuela(engine.Escuela, "foreach");

        engine.Escuela.Cursos.RemoveAll((Cur) =>
           Cur.Nombre == "Quimica" && Cur.Jornada == TiposJornada.Mañana);

    }


}