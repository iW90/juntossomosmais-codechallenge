using jsmclients.Core.Entities;
using jsmclients.Core.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace jsmclients.Core.Interfaces
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<IEnumerable<Client>> ElegibleList(ClientRegionEnum region, ClientTypeEnum type);
    }
}
