using System.Text.Json.Serialization;

namespace JSMClientsRegistries.Core.DTOs
{
    public class TimezoneDTO
    {
        [JsonPropertyName("offset")]
        public string Offset { get; set; }


        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
