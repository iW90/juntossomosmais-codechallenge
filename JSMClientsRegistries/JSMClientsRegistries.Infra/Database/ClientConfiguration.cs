using JSMClientsRegistries.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JSMClientsRegistries.Infra.Database
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");

            builder.HasKey(pk => pk.Id);

            builder.Property(p => p.Type)
                .HasColumnType("INT");
            builder.Property(p => p.Gender)
                .HasColumnType("CHAR(1)");
            builder.Property(p => p.TitleName)
                .HasColumnType("VARCHAR(10)");
            builder.Property(p => p.FirstName)
                .HasColumnType("VARCHAR(50)");
            builder.Property(p => p.LastName)
                .HasColumnType("VARCHAR(50)");
            builder.Property(p => p.Email)
                .HasColumnType("VARCHAR(100)");
            builder.Property(p => p.DobDate)
                .HasColumnType("DATETIME");
            builder.Property(p => p.RegisteredDate)
                .HasColumnType("DATETIME");
            builder.Property(p => p.Phone)
                .HasColumnType("CHAR(20)");
            builder.Property(p => p.Cel)
                .HasColumnType("CHAR(20)");
            builder.Property(p => p.Nationality)
                .HasColumnType("CHAR(2)")
                .HasDefaultValue("BR");

            builder.HasOne(fk => fk.Location)
                .WithOne(fk => fk.Client)
                .HasForeignKey<Client>(fk => fk.IdLocation)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(fk => fk.Pictures)
                .WithOne(fk => fk.Client)
                .HasForeignKey<Client>(fk => fk.IdPicture)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
