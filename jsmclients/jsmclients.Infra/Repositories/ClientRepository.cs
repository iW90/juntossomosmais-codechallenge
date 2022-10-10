using jsmclients.Core.Entities;
using jsmclients.Core.Enums;
using jsmclients.Core.Interfaces;
using jsmclients.Infra.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jsmclients.Infra.Repositories
{
    public class ClientRepository : IClientRepository
    {
        //Vincula-se ao BD implementado pelo Migrations
        private readonly ApplicationContext _context;

        public ClientRepository(ApplicationContext context)
        {
            _context = context;
        }

        //Métodos
        public async Task<IEnumerable<Client>> ElegibleList(ClientRegionEnum region, ClientTypeEnum type)
        {
            return await _context
                .Client
                .Include(x => x.Location)
                .Include(x => x.Pictures)
                .Where(x => x.Type == type)
                .Where(x => x.Location.Region == region)
                .AsNoTracking()
                .ToListAsync();
            /*
            return new List<Client>()
            {
                new Client()
                {
                    Id = 1,
                    Gender = "F",
                    TitleName = "sra.",
                    FirstName = "Cleid",
                    LastName = "Silva",
                    Email = "abc@def.com",
                    DobDate = DateTime.Now,
                    RegisteredDate = DateTime.Now,
                    Phone = "123",
                    Cel = "1234",
                    Nationality = "BR",
                    Location = new Location()
                    {
                        Id = 1,
                        Street = "abc",
                        City = "def",
                        State = "amapá",
                        Postcode = 123,
                        Latitude = "-69.8704M",
                        Longitude = "-165.9545M",
                        TimezoneOffset = "+1:00",
                        TimezoneDescription = "Brussels, Copenhagen, Madrid, Paris"
                    },
                    Pictures = new Pictures()
                    {
                        Id = 1,
                        Large = "asdas",
                        Medium = "asdasf",
                        Thumbnail = "asgasgas"
                    }
                }
            };
            */
        }
    }
}
