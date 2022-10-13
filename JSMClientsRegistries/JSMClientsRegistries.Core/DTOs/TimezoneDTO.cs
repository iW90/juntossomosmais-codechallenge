using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace JSMClientsRegistries.Core.DTOs
{
    public class TimezoneDTO
    {
        [JsonProperty("offset")]
        public string Offset { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
