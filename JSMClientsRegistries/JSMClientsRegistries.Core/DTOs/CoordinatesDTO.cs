using System.Text.Json.Serialization;

namespace JSMClientsRegistries.Core.DTOs
{
    public class CoordinatesDTO
    {
        [JsonPropertyName("latitude")]
        public string Latitude { get; set; }


        [JsonPropertyName("longitude")]
        public string Longitude { get; set; }
    }
}
