using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace JSMClientsRegistries.Core.DTOs
{
    public class ResultsDTO
    {
        [JsonPropertyName("results")]
        public List<ClientDTO> Results { get; set; }
    }
}
