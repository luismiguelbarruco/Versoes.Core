using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
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

            modelBuilder.Entity<Setor>().HasData(
                new Setor
                {
                    Id = 1,
                    Nome = "Desenvolvimento",
                    Status = StatusDeCadastro.Normal
                },
                new Setor
                {
                    Id = 2,
                    Nome = "Suporte",
                    Status = StatusDeCadastro.Normal
                },
                new Setor
                {
                    Id = 3,
                    Nome = "Teste",
                    Status = StatusDeCadastro.Normal
                },
                new Setor
                {
                    Id = 4,
                    Nome = "Financeiro",
                    Status = StatusDeCadastro.Normal
                },
                new Setor
                {
                    Id = 5,
                    Nome = "Admin",
                    Status = StatusDeCadastro.Normal
                }
            );

            modelBuilder.Entity<Usuario>().HasData(new Usuario 
            { 
                Id = 1,
                Login = "admin",
                Senha = "jL0Xh/2fRnMB/2lfILO9MQ==", //admin123
                Nome = "Administrador",
                Sigla = "ADM",
                SetorId = 5,
                Status = StatusDeCadastro.Normal
            });
        }
    }

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
