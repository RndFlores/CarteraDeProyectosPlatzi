using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization; // para la Key

namespace WebApi.Models;
public class Categoria
{
    //[Key] //forzamos a que use esto como Id
    public Guid CategoriaId { get; set; }//Entity Framework le permite automaticamente identificar cual es el id, porq termina en id

    //[Required]//campo requerido
    //[MaxLength(255)]//cantidad de caracteres
    public string Nombre { get; set; }
    public string Descripcion { get; set; }

    public int Peso {  get; set; }

    [JsonIgnore]// por el momento cuando hacemos el uso de la ruta /api/tareas para que no traiga la colleccion de tareas y se forme un ciclo usamos esto
    //traer todas las tareas que estaran asociadas con categorias
    public virtual ICollection<Tarea> Tareas { get; set; }
}

