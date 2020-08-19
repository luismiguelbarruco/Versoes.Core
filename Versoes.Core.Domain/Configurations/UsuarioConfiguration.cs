using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Versoes.Entities.Models;

namespace Versoes.Entities.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasIndex(usuario => usuario.Id).IsUnique();
            builder.HasIndex(usuario => usuario.Nome).IsUnique();
            builder.HasIndex(usuario => usuario.Login).IsUnique();

            builder.Property(usuario => usuario.Id).ValueGeneratedOnAdd();
            builder.Property(usuario => usuario.Nome).HasMaxLength(100).IsRequired();
            builder.Property(usuario => usuario.Login).HasMaxLength(20).IsRequired();
            builder.Property(usuario => usuario.Senha).HasMaxLength(20).IsRequired();
            builder.Property(usuario => usuario.Status).IsRequired();

            builder.HasOne<Setor>(usuario => usuario.Setor)
                .WithOne(us => us.Usuario)
                .HasForeignKey<Usuario>(us => us.SetorId);
        }
    }
}
