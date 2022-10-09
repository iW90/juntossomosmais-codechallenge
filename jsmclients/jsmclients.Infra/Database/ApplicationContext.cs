using jsmclients.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace jsmclients.Infra.Database
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Client> Client { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Pictures> Pictures { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new LocationConfiguration());
            modelBuilder.ApplyConfiguration(new PicturesConfiguration());
        }
    }
}

/*
- Comando para criar o arquivo Migrations:
dotnet ef --startup-project ./jsmclients.API/jsmclients.API.csproj  migrations add Tables -p ./jsmclients.Infra/jsmclients.Infra.csproj

- Comando para criar as tabelas no SQL (enquanto o update automático está desabilitado):
dotnet ef database update --project ./jsmclients.Infra
 */