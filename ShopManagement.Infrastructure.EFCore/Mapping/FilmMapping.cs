using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.FilmAgg;
using ShopManagement.Domain.SlideAgg;

namespace ShopManagement.Infrastructure.EFCore.Mapping;

public class FilmMapping : IEntityTypeConfiguration<Film>
{
    public void Configure(EntityTypeBuilder<Film> builder)
    {
        builder.ToTable("Films");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Image).HasMaxLength(1000).IsRequired();
        builder.Property(x => x.PictureAlt).HasMaxLength(500).IsRequired();
        builder.Property(x => x.PictureTitle).HasMaxLength(500).IsRequired();
        builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(500);
        builder.Property(x => x.Url).HasMaxLength(1000);
    }
}