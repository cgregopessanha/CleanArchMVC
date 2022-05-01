using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        // Construtor para Definir as opções do contexto 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        //Mapeamento ORM
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        //Definindo as configurações das Entidades
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            //A linha a seguir informa que serão configuradas todas as classe do assembly que implementem a interface IEntityTypeConfiguration
            
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
