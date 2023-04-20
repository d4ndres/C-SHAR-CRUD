
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _02_learn_entity_framework_core.Models;

public class Tarea
{
    //[Key]
    public Guid TareaId { get; set; }

    //[ForeignKey("CategoriaId")]
    public Guid CategoriaId { get; set; }

    //[Required]
    //[MaxLength(100)]
    public string Titulo {get;set;}

    public string Description {get;set;}

    public Prioridad PrioridadTarea { get;set;}

    public DateTime FechaCreacion { get; set;}


    // Me permite traer la informacion general que existe en esa categoria
    public virtual Categoria Categoria { get; set; }

    // Esta propiedad no se crea en la db. Por su DataNotation
    //[NotMapped]
    public string Resumen { get;set;}
    
}

public enum Prioridad
{
    Baja,
    Media,
    Alta
}