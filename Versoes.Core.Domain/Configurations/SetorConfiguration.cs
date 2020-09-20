using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;
using Versoes.Entities.Models;
using Versoes.Core.Domain.ValueObjects;

namespace Versoes.Entities.Configurations
{
    [ExcludeFromCodeCoverage]
    public class SetorConfiguration : IEntityTypeConfiguration<Setor>
    {
        public void Configure(EntityTypeBuilder<Setor> builder)
        {
            builder.ToTable("Setores");

            builder.HasKey(setor => setor.Id);
            builder.HasIndex(setor => setor.Nome).IsUnique();

            builder.Property(setor => setor.Id).ValueGeneratedOnAdd();
            builder.Property(setor => setor.Nome).HasMaxLength(30).IsRequired();
            builder.Property(setor => setor.Status).IsRequired();

            builder.HasData(
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
        }
    }
}