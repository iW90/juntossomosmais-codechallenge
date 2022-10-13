using System.Text.Json.Serialization;

namespace JSMClientsRegistries.Core.DTOs
{
    public class PictureDTO
    {
        [JsonPropertyName("large")]
        public string Large { get; set; }


        [JsonPropertyName("medium")]
        public string Medium { get; set; }


        [JsonPropertyName("thumbnail")]
        public string Thumbnail { get; set; }
    }
}
