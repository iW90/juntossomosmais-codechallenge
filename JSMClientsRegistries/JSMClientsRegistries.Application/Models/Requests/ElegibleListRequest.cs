using JSMClientsRegistries.Core.Enums;

namespace JSMClientsRegistries.Application.Models.Requests
{
    public class ElegibleListRequest
    {
        public ClientTypeEnum Type { get; set; }
        public ClientRegionEnum Region { get; set; }
    }
}
