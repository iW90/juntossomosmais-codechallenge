using System.Text.Json.Serialization;

namespace JSMClientsRegistries.Core.DTOs
{
    public class NameDTO
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }


        [JsonPropertyName("first")]
        public string First { get; set; }


        [JsonPropertyName("last")]
        public string Last { get; set; }
    }
}
