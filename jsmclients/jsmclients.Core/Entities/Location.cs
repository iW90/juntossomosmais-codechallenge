using jsmclients.Core.Enums;

namespace jsmclients.Core.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public ClientRegionEnum Region { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Postcode { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string TimezoneOffset { get; set; }
        public string TimezoneDescription { get; set; }
        public Client Client { get; set; }
    }
}
