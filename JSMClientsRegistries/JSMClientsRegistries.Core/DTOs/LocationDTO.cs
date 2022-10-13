using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace JSMClientsRegistries.Core.DTOs
{
    public class LocationDTO
    {
        [JsonProperty("street")]
        public string Street { get; set; }


        [JsonProperty("city")]
        public string City { get; set; }


        [JsonProperty("state")]
        public string State { get; set; }


        [JsonProperty("postcode")]
        public int Postcode { get; set; }

        [JsonProperty("coordinates")]
        public CoordinatesDTO Coordinates { get; set; }


        [JsonProperty("timezone")]
        public TimezoneDTO Timezone { get; set; }
    }
}
