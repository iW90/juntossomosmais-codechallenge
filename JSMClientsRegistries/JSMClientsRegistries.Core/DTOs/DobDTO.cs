using System.Text.Json.Serialization;

namespace JSMClientsRegistries.Core.DTOs
{
    public class DobDTO
    {
        [JsonPropertyName("date")]
        public string Date { get; set; }


        [JsonPropertyName("age")]
        public int Age { get; set; }
    }
}
