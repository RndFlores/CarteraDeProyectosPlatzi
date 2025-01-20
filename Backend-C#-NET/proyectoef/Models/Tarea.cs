using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyectoef.Models;

public class Tarea
{
    //[Key] ya no es necesario porqeu estamos usando FLUENTAPI
    public Guid TareaId { get; set; }
    //[ForeignKey("CategoriaId")]
    public Guid CategoriaId { get; set; }
    //[Required]
    //[MaxLength(200)]
    public string Titulo {  get; set; }

    public string Descripcion {  get; set; }
    public Prioridad PrioridadTarea { get; set; }
    public DateTime FechaCreacion { get; set; }

    // cada tarea tendra asignada una categoria
    public virtual Categoria categoria { get; set; }

    //propiedad que se va a lelnar con Titulo y Descripcion
    //[NotMapped]//En el momento que se haga el mapeo, del contexto a la bd esto sea omitido
    public string Resumen {  get; set; }
}

public enum Prioridad
{
    Baja,
    Media,
    Alta
}

