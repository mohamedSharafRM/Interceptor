using Interceptor.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Interceptor.Data.Configurations;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Name)
            .HasMaxLength(50);

        builder.Property(p => p.Description)
            .HasMaxLength(150);

        builder.Property(p => p.Price)
            .HasPrecision(10, 2);

        builder.HasIndex(p => p.Name)
            .IsUnique();
    }
}
