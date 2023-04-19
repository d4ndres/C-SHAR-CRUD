using System.ComponentModel.DataAnnotations;

namespace _02_learn_entity_framework_core.Models;

public class Categoria
{
    [Key]
    public Guid CategoriaId { get; set; }

    [Required]
    [MaxLength(150)]
    public string Nombre { get; set;}

    public string Description {get;set;}


    // Me permite traer todas las tareas que poseen esta categoria
    public virtual ICollection<Tarea> Tareas {get;set;}
}