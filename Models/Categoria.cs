using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace _02_learn_entity_framework_core.Models;

public class Categoria
{
    //[Key]
    public Guid CategoriaId { get; set; }

    //[Required]
    //[MaxLength(150)]
    public string Nombre { get; set; }

    public string Description { get; set; }

    public int Peso { get; set; }


    [JsonIgnore]
    // Me permite traer todas las tareas que poseen esta categoria
    public virtual ICollection<Tarea> Tareas { get; set; }
}