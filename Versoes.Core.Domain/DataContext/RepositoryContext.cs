using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Versoes.Entities.Models;

namespace Versoes.Entities
{
    [ExcludeFromCodeCoverage]
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

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RepositoryContext).Assembly);
        }
    }

    [ExcludeFromCodeCoverage]
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@Directory.GetCurrentDirectory() + "../../Versoes.Core.Api/appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<RepositoryContext>();

            var connectionString = configuration["postgresConnection:connectionString"];
            
            builder.UseNpgsql(connectionString);

            return new RepositoryContext(builder.Options);
        }
    }
}
