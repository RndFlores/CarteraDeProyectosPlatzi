using WebApi.Models;

namespace WebApi.Services
{
    public class TareaServices:ITareaService
    {
        TareasContext context;
        public TareaServices(TareasContext dbcontext)
        {
            this.context = dbcontext;
        }

        public IEnumerable<Tarea> Get()
        {
            return context.Tareas;
        }
        public async Task Save(Tarea tarea)
        {
            context.Add(tarea);
            await context.SaveChangesAsync();
        }
        public async Task Update(Guid id, Tarea tarea)
        {
            var tareaActual= context.Tareas.Find(id);
            if(tareaActual!= null) {
                tareaActual.Titulo = tarea.Titulo;
                tareaActual.Descripcion = tarea.Descripcion;
                tareaActual.categoria = tarea.categoria;
                tareaActual.PrioridadTarea = tarea.PrioridadTarea;
                tareaActual.Resumen=tarea.Resumen;
                await context.SaveChangesAsync();
            }
        }
        public async Task Delete(Guid id)
        {
            var tareaActual=context.Tareas.Find(id);
            if (tareaActual != null)
            {
                context.Remove(tareaActual);
                await context.SaveChangesAsync();
            }
        }
    }

    public interface ITareaService
    {
        IEnumerable<Tarea> Get();
        Task Save(Tarea tarea);
        Task Update(Guid id, Tarea tarea);
        Task Delete(Guid id);
    }
}
