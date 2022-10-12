namespace JSMClientsRegistries.Core.Entities
{
    public class Pictures
    {
        public int Id { get; private set; }
        public string Large { get; private set; }
        public string Medium { get; private set; }
        public string Thumbnail { get; private set; }
        public Client Client { get; private set; }
    }
}
