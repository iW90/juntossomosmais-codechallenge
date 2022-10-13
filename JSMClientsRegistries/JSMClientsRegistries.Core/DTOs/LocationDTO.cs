using System.Text.Json.Serialization;

namespace JSMClientsRegistries.Core.DTOs
{
    public class LocationDTO
    {
        [JsonPropertyName("street")]
        public string Street { get; set; }


        [JsonPropertyName("city")]
        public string City { get; set; }


        [JsonPropertyName("state")]
        public string State { get; set; }


        [JsonPropertyName("postcode")]
        public int Postcode { get; set; }


        [JsonPropertyName("coordinates")]
        public CoordinatesDTO Coordinates { get; set; }


        [JsonPropertyName("timezone")]
        public TimezoneDTO Timezone { get; set; }
    }
}
