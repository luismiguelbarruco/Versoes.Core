using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Versoes.Entities.Models;

namespace Versoes.Entities.Configurations
{
    public class SetorConfiguration : IEntityTypeConfiguration<Setor>
    {
        public void Configure(EntityTypeBuilder<Setor> builder)
        {
            builder.ToTable("Setor");

            builder.HasKey(setor => setor.Id);
            builder.HasIndex(setor => setor.Nome).IsUnique();

            builder.Property(setor => setor.Id).ValueGeneratedOnAdd();
            builder.Property(setor => setor.Nome).HasMaxLength(100).IsRequired();
            builder.Property(setor => setor.Status).IsRequired();
        }
    }
}
