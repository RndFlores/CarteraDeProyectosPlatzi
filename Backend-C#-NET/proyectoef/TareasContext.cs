using Microsoft.EntityFrameworkCore;
using proyectoef.Models;

namespace proyectoef
{
    //dbcontext tiene todos los componentes para crear la condiguracion de base de datos
    public class TareasContext : DbContext 
    {
        //representatn toda la coleccion de todos los datos
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Tarea> Tareas { get; set; }

        //BASE DEL CONSTRUCTOR
        public TareasContext(DbContextOptions <TareasContext> options): base(options) { }
    }
}
