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

        //ESTO ES FLUENTAPI
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            //hacer las restricciones que necesito para este modelo en particular
            modelbuilder.Entity<Categoria>(categoria =>
            {
                //es importante especificar cada campo
                categoria.ToTable("Categoria");//especificar que se debe convertir en una tabla, además que el nombre debe estar en singular
                categoria.HasAlternateKey(c=>c.CategoriaId);
                categoria.Property(c => c.Nombre).IsRequired().HasMaxLength(255);
                categoria.Property(c => c.Descripcion);
            });

            modelbuilder.Entity<Tarea>(tarea =>
            {
                tarea.ToTable("Tarea");
                tarea.HasAlternateKey(t => t.TareaId);
                tarea.HasOne(t => t.categoria).WithMany(t => t.Tareas).HasForeignKey(t=>t.CategoriaId);
                tarea.Property(t=>t.Titulo).IsRequired().HasMaxLength(200);
                tarea.Property(t=>t.Descripcion);
                tarea.Property(t => t.PrioridadTarea);
                tarea.Property(t => t.FechaCreacion);
                //como queremos que RESUMEN no sea mapeado no lo agregamos aca
            });
        }
    }
}
