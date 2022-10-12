using JSMClientsRegistries.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace JSMClientsRegistries.Infra.Database
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
dotnet ef --startup-project ./JSMClientsRegistries.API/JSMClientsRegistries.API.csproj  migrations add ClientRegistries -p ./JSMClientsRegistries.Infra/JSMClientsRegistries.Infra.csproj

- Comando para criar as tabelas no SQL (enquanto o update automático está desabilitado):
dotnet ef database update --project ./JSMClientsRegistries.API
 */