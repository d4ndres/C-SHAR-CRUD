
// Requerimientos que importamos al archivo.
using _02_learn_entity_framework_core.Models;
using Microsoft.EntityFrameworkCore;


// Agrega un alias a la clase "TareasContext"
namespace _02_learn_entity_framework_core.Context
{
    // Nuestra clase 
    public class TareasContext : DbContext
    {
        //Metodo categorias que retorna un instancia de dato DbSet<Categoria>
        public DbSet<Categoria> Categorias { get; set; }
        
        public DbSet<Tarea> Tareas { get; set; }

        public TareasContext(DbContextOptions<TareasContext> options) : base(options) 
        {

        }
        

    }
}