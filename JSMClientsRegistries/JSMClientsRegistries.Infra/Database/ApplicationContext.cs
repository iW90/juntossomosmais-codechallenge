using JSMClientsRegistries.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace JSMClientsRegistries.Infra.Database
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Picture> Pictures { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientsConfiguration());
            modelBuilder.ApplyConfiguration(new LocationsConfiguration());
            modelBuilder.ApplyConfiguration(new PicturesConfiguration());
        }
    }
}

/*
- Comando para criar o arquivo Migrations:
dotnet ef --startup-project ./JSMClientsRegistries.API/JSMClientsRegistries.API.csproj  migrations add ClientRegistries -p ./JSMClientsRegistries.Infra/JSMClientsRegistries.Infra.csproj

- Comando para criar as tabelas no SQL (enquanto o update automático está desabilitado):
dotnet ef database update --project ./JSMClientsRegistries.API
 */