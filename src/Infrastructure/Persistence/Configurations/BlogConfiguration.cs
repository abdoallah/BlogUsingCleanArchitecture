
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations;
public class BlogConfiguration  : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
{
     builder.Property(t => t.Title)
        .HasMaxLength(100)
        .IsRequired();

        builder.Property(b => b.Body)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(d => d.CreationDate)
            .IsRequired();
}
}

