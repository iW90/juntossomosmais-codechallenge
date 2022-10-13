using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace JSMClientsRegistries.Core.DTOs
{
    public class CoordinatesDTO
    {
        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }
    }
}
