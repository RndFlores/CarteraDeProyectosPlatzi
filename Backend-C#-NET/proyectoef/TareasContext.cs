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
            List<Categoria>CategoriasInit= new List<Categoria>();
            CategoriasInit.Add(new Categoria()
            {
                CategoriaId = Guid.Parse("f41a95e0-c087-4fa2-9e36-2bc00c959e4f"),
                Nombre = "Actividades pendientes",
                Descripcion="Tareas que aún no han sido completadas",
                Peso =20
            });
            CategoriasInit.Add(new Categoria()
            {
                CategoriaId = Guid.Parse("f41a95e0-c087-4fa2-9e36-2bc00c959e01"),
                Nombre = "Actividades Personales",
                Descripcion="Actividades realcionadas con el ámbito personal",
                Peso = 50
            });



            //hacer las restricciones que necesito para este modelo en particular
            modelbuilder.Entity<Categoria>(categoria =>
            {
                //es importante especificar cada campo
                categoria.ToTable("Categoria");//especificar que se debe convertir en una tabla, además que el nombre debe estar en singular
                categoria.HasAlternateKey(c=>c.CategoriaId);
                categoria.Property(c => c.Nombre).IsRequired().HasMaxLength(255);
                categoria.Property(c => c.Descripcion);

                categoria.Property(c => c.Peso);

                //AGRAGAR DATOS A LA CATEGORIA
                categoria.HasData(CategoriasInit);
            });

            List<Tarea> TareasInit= new List<Tarea>();
            TareasInit.Add(new Tarea()
            {
                TareaId= Guid.Parse("3b490b5b-4f04-4fe3-97c7-515d53370857"),
                CategoriaId= Guid.Parse("f41a95e0-c087-4fa2-9e36-2bc00c959e4f"),
                Titulo="Pago de servicios publicos",
                Descripcion="Debo pagar los servicio publicos que tengo pendiente",
                PrioridadTarea= Prioridad.Media,
                FechaCreacion = new DateTime(2025,1,1)
            });
            TareasInit.Add(new Tarea()
            {
                TareaId = Guid.Parse("3b490b5b-4f04-4fe3-97c7-515d53370818"),
                CategoriaId = Guid.Parse("f41a95e0-c087-4fa2-9e36-2bc00c959e01"),
                Titulo = "Terminar de ver mi serie",
                Descripcion = "Acabemos la serie yei!!",
                PrioridadTarea = Prioridad.Baja,
                FechaCreacion = new DateTime(2025,1,1)
            });

            modelbuilder.Entity<Tarea>(tarea =>
            {
                tarea.ToTable("Tarea");
                tarea.HasAlternateKey(t => t.TareaId);
                tarea.HasOne(t => t.categoria).WithMany(t => t.Tareas).HasForeignKey(t=>t.CategoriaId);
                tarea.Property(t=>t.Titulo).IsRequired().HasMaxLength(200);
                tarea.Property(t=>t.Descripcion);
                tarea.Property(t => t.PrioridadTarea);
                tarea.Property(t => t.FechaCreacion).HasDefaultValue(new DateTime (2025,1,1));
                //como queremos que RESUMEN no sea mapeado usaremos ignore
                tarea.Ignore(t => t.Resumen);

                tarea.HasData(TareasInit);
            });
        }
    }
}
