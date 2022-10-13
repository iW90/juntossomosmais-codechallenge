using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace JSMClientsRegistries.Core.DTOs
{
    public class NameDTO
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("first")]
        public string First { get; set; }

        [JsonProperty("last")]
        public string Last { get; set; }
    }
}
