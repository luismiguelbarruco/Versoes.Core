using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;
using Versoes.Entities.Models;

namespace Versoes.Core.Domain.Configurations
{
    [ExcludeFromCodeCoverage]
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.NomeFantasia).HasMaxLength(60).IsRequired();
            builder.Property(c => c.Cancelado).HasDefaultValue(false).IsRequired();
        }
    }
}
