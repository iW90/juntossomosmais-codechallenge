using JSMClientsRegistries.Core.Enums;

namespace JSMClientsRegistries.Application.Models.Responses
{
    public class LocationResponse
    {
        public ClientRegionEnum Region { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Postcode { get; set; }
        public CoordinatesResponse Coordinates { get; set; }
        public TimezoneResponse Timezone { get; set; }
    }
}
