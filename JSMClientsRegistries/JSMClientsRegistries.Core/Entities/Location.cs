using JSMClientsRegistries.Core.Enums;

namespace JSMClientsRegistries.Core.Entities
{
    public class Location
    {
        public int Id { get; private set; }
        public ClientRegionEnum Region { get; private set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public int Postcode { get; private set; }
        public string Latitude { get; private set; }
        public string Longitude { get; private set; }
        public string TimezoneOffset { get; private set; }
        public string TimezoneDescription { get; private set; }
        public Client Client { get; private set; }
    }
}
