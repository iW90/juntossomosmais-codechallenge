using jsmclients.Infra.Database;
using jsmclients.Core.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Tests.DBInMemory
{
    public class DBInMemory
    {/*
        private ApplicationContext _context;

        public DBInMemory()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseSqlite(connection)
                .EnableSensitiveDataLogging()
                .Options;

            _context = new ApplicationContext(options);
            InsertFakeData();
        }

        public ApplicationContext GetContext() => _context;

        private void InsertFakeData()
        {
            if (_context.DatabaseEnsureCreated())
            {
                _context.Clients.Add(
                    new Clients(1, "laborious", "F", "abc@def.com", "1956-02-12T10:38:37Z", "1956-02-12T10:38:37Z", "123", "123", "BR")
                );
                _context.SaveChanges();

            }
    }*/
        }
}
