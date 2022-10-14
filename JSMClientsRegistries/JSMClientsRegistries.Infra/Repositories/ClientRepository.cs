using JSMClientsRegistries.Core.Entities;
using JSMClientsRegistries.Core.Enums;
using JSMClientsRegistries.Core.Interfaces;
using JSMClientsRegistries.Infra.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JSMClientsRegistries.Infra.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationContext _context;

        public ClientRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<int> CountElegibleList(ClientRegionEnum region, ClientTypeEnum type)
        {
            return await _context
                .Clients
                    .Include(x => x.Location)
                .Where(x => x.Type == type)
                .Where(x => x.Location.Region == region)
                .AsNoTracking()
                .CountAsync();
        }

        public async Task<IEnumerable<Client>> ElegibleList(ClientRegionEnum region, ClientTypeEnum type, int pageNumber, int pageSize)
        {
            return await _context
                .Clients
                    .Include(x => x.Location)
                    .Include(x => x.Picture)
                .Where(x => x.Type == type)
                .Where(x => x.Location.Region == region)
                .AsNoTracking()
                //.OrderBy(x => x.Nationality)
                .Skip(pageNumber - 1)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
