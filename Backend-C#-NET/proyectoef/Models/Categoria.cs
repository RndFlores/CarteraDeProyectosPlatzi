using System.ComponentModel.DataAnnotations; // para la Key

namespace proyectoef.Models;
public class Categoria
{
    //[Key] //forzamos a que use esto como Id
    public Guid CategoriaId { get; set; }//Entity Framework le permite automaticamente identificar cual es el id, porq termina en id

    //[Required]//campo requerido
    //[MaxLength(255)]//cantidad de caracteres
    public string Nombre { get; set; }
    public string Descripcion { get; set; }

    public int Peso {  get; set; }

    //traer todas las tareas que estaran asociadas con categorias
    public virtual ICollection<Tarea> Tareas { get; set; }
}

