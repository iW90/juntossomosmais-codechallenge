using JSMClientsRegistries.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JSMClientsRegistries.Infra.Database
{
    public class PicturesConfiguration : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.ToTable("Pictures");

            builder.HasKey(pk => pk.Id);

            builder.Property(p => p.Large)
                .HasColumnType("VARCHAR(255)");
            builder.Property(p => p.Medium)
                .HasColumnType("VARCHAR(255)");
            builder.Property(p => p.Thumbnail)
                .HasColumnType("VARCHAR(255)");
        }
    }
}
