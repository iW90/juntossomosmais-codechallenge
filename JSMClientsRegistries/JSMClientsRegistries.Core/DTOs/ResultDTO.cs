using Newtonsoft.Json;
using System.Collections.Generic;

namespace JSMClientsRegistries.Core.DTOs
{
    public class ResultDTO
    {
        [JsonProperty("results")]
        public List<ClientDTO> Results { get; set; }
    }
}
