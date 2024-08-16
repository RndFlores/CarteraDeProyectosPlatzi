using CoreEscuela.Entidades;

namespace CoreEscuela;
public class EscuelaEngine
{
    public Escuela Escuela { get; set; }
    public EscuelaEngine()
    {

    }
    public void Inicializar()
    {
        this.Escuela = new Escuela("Platzi Academy", 2012, "Colombia", "Bogota", TiposEscuela.Secundaria);
        CargarCursos();
        CargarAsignatura();
        CargarEvaluaciones();
    }

    private List<Alumno> GenerarAlumnosAlAzar(int cantRandom)
    {
        string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolas" };
        string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
        string[] nombre2 = { "Freddy", "Anabel", "Rick", "Muricio", "Silvestre", "Don", "Jose" };

        var AlumnosRandom = from n1 in nombre1
                            from n2 in nombre2
                            from a1 in apellido1
                            select new Alumno { Nombre = $"{n1} {n2} {a1}" };

        return AlumnosRandom.OrderBy(
            (al) => al.UniqueId
        ).Take(cantRandom).ToList();
    }
    private void CargarCursos()
    {
        Escuela.Cursos = new List<Curso>(){
            new Curso(){Nombre="101", Jornada=TiposJornada.Mañana},
            new Curso(){Nombre="102", Jornada=TiposJornada.Mañana},
            new Curso(){Nombre="103", Jornada=TiposJornada.Mañana},
            new Curso(){Nombre="201", Jornada=TiposJornada.Tarde},
            new Curso(){Nombre="202", Jornada=TiposJornada.Tarde},
            new Curso(){Nombre="203", Jornada=TiposJornada.Tarde},
            new Curso(){Nombre="301", Jornada=TiposJornada.Noche},
            new Curso(){Nombre="302", Jornada=TiposJornada.Noche},
            new Curso(){Nombre="303", Jornada=TiposJornada.Noche}
        };
        Random rnd = new Random();
        foreach (var c in Escuela.Cursos)
        {
            int cantRandom = rnd.Next(5, 20);
            c.Alumnos = GenerarAlumnosAlAzar(cantRandom);
        }

    }



    private void CargarAsignatura()
    {
        foreach (var curso in Escuela.Cursos)
        {
            List<Asignatura> ListadoAsignaturas = new List<Asignatura>(){
                new Asignatura{Nombre="Matematicas"},
                new Asignatura{Nombre="Educacion Fisica"},
                new Asignatura{Nombre="Castellano"},
                new Asignatura{Nombre="Ciencias Naturales"},
                new Asignatura{Nombre="Programacion"}
            };
            curso.Asignaturas = ListadoAsignaturas;
        }
    }

    private void CargarEvaluaciones()
    {
        var rnd = new Random();

        foreach (Curso cur in Escuela.Cursos)
        {
            var evaluacion = from Alumno in cur.Alumnos
                             from Asignatura in cur.Asignaturas
                             select new Evaluaciones
                             {
                                 Nombre = $"{Asignatura.Nombre} - {Alumno.Nombre}",
                                 Asignatura = Asignatura,
                                 Alumno = Alumno,
                                 Nota = rnd.Next(0, 20) / 5.0f
                             };
            cur.Evaluaciones = evaluacion.ToList();
        }
    }
}