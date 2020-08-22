using Microsoft.EntityFrameworkCore;
using Versoes.Entities.Configurations;
using Versoes.Entities.Models;

namespace Versoes.Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options)
            : base(options)
        {
#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
                this.Database.EnsureCreated();
#endif
        }

        public DbSet<Setor> Setores { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        // public DbSet<Requisito> Requisitos { get; set; }
        // public DbSet<Bug> Bugs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new SetorConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new ProjetoConfiguration());
        }
    }
}
