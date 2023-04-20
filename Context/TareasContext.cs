
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
         
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>( categoria => 
            {
                categoria.ToTable("Categoria");
                categoria.HasKey( p => p.CategoriaId );
                categoria.Property( p => p.Nombre ).IsRequired().HasMaxLength(150);
                categoria.Property( p => p.Description );
                categoria.Property( p => p.Peso );
            });

            modelBuilder.Entity<Tarea>( tarea => 
            {
                tarea.ToTable("Tarea");
                tarea.HasKey( p => p.TareaId );
                tarea.HasOne( p => p.Categoria ).WithMany( p => p.Tareas ).HasForeignKey( p => p.CategoriaId );
                tarea.Property( p => p.Titulo ).IsRequired().HasMaxLength(150);
                tarea.Property( p => p.Description );
                tarea.Property( p => p.PrioridadTarea );
                tarea.Property( p => p.FechaCreacion );
                tarea.Ignore( p => p.Resumen );
            });            
        }

    }
}