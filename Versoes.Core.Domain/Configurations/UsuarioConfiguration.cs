using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;
using Versoes.Entities.Models;
using Versoes.Core.Domain.ValueObjects;

namespace Versoes.Entities.Configurations
{
    [ExcludeFromCodeCoverage]
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");
            builder.HasIndex(usuario => usuario.Id).IsUnique();
            builder.HasIndex(usuario => usuario.Nome).IsUnique();
            builder.HasIndex(usuario => usuario.Login).IsUnique();

            builder.Property(usuario => usuario.Id).ValueGeneratedOnAdd();
            builder.Property(usuario => usuario.Nome).HasMaxLength(60).IsRequired();
            builder.Property(usuario => usuario.Sigla).HasMaxLength(5).IsRequired();
            builder.Property(usuario => usuario.Login).HasMaxLength(20).IsRequired();
            builder.Property(usuario => usuario.Senha).HasMaxLength(40).IsRequired();
            builder.Property(usuario => usuario.Status).IsRequired();

            builder.HasOne(usuario => usuario.Setor);

            builder.HasData(new Usuario
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
}
