using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;
using Versoes.Entities.Models;

namespace Versoes.Entities.Configurations
{
    [ExcludeFromCodeCoverage]
    public class ProjetoConfiguration : IEntityTypeConfiguration<Projeto>
    {
        public void Configure(EntityTypeBuilder<Projeto> builder)
        {
            builder.ToTable("Projetos");

            builder.HasKey(projeto => projeto.Id);
            builder.HasIndex(projeto => projeto.Nome).IsUnique();

            builder.Property(projeto => projeto.Id).ValueGeneratedOnAdd();
            builder.Property(projeto => projeto.Nome).HasMaxLength(60).IsRequired();
            builder.Property(projeto => projeto.Status).IsRequired();
        }
    }
}
