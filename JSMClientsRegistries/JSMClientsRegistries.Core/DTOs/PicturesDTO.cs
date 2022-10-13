using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace JSMClientsRegistries.Core.DTOs
{
    public class PicturesDTO
    {
        [JsonProperty("large")]
        public string Large { get; set; }
        [JsonProperty("medium")]


        public string Medium { get; set; }
        [JsonProperty("thumbnail")]


        public string Thumbnail { get; set; }
    }
}
