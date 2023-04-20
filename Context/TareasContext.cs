
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
            List<Categoria> categoriaInit = new List<Categoria>();
            categoriaInit.Add( new Categoria() 
            { 
                CategoriaId = Guid.Parse("766970ac-6a58-4c4d-b9b3-f9ccfd976e94"),
                Nombre = "Actividades pendientes",
                Peso = 20,
                Description = "Sacar al perro, ir de compras y salvar el mundo"
            });
            categoriaInit.Add( new Categoria() 
            { 
                CategoriaId = Guid.Parse("266970ac-6a58-4c4d-b9b3-f9ccfd976e94"),
                Nombre = "Actividades personales",
                Peso = 10,
                Description = "Cortar pelo"
            });


            modelBuilder.Entity<Categoria>( categoria => 
            {
                categoria.ToTable("Categoria");
                categoria.HasKey( p => p.CategoriaId );
                categoria.Property( p => p.Nombre ).IsRequired().HasMaxLength(150);
                categoria.Property( p => p.Description ).IsRequired(false);
                categoria.Property( p => p.Peso );

                categoria.HasData( categoriaInit );
            });


            List<Tarea> TareaInit = new List<Tarea>();
            TareaInit.Add( new Tarea() 
            { 
                TareaId = Guid.Parse("762370ac-6a58-4c4d-b9b3-f9ccfd976e94"),
                CategoriaId = Guid.Parse("766970ac-6a58-4c4d-b9b3-f9ccfd976e94"),
                PrioridadTarea = Prioridad.Media,
                Titulo = "Pago de servicios",
                FechaCreacion = DateTime.Now
            });

            TareaInit.Add( new Tarea() 
            { 
                TareaId = Guid.Parse("762370ac-6a58-4c4d-b9b3-f9ccfd976e92"),
                CategoriaId = Guid.Parse("766970ac-6a58-4c4d-b9b3-f9ccfd976e94"),
                PrioridadTarea = Prioridad.Baja,
                Titulo = "Ver pelicula",
                FechaCreacion = DateTime.Now
            });


            modelBuilder.Entity<Tarea>( tarea => 
            {
                tarea.ToTable("Tarea");
                tarea.HasKey( p => p.TareaId );
                tarea.HasOne( p => p.Categoria ).WithMany( p => p.Tareas ).HasForeignKey( p => p.CategoriaId );
                tarea.Property( p => p.Titulo ).IsRequired().HasMaxLength(150);
                tarea.Property( p => p.Description ).IsRequired(false);
                tarea.Property( p => p.PrioridadTarea );
                tarea.Property( p => p.FechaCreacion );
                tarea.Ignore( p => p.Resumen );

                tarea.HasData( TareaInit );
            });            
        }

    }
}