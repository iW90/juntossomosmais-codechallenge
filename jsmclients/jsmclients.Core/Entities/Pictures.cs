namespace jsmclients.Core.Entities
{
    public class Pictures
    {
        public int Id { get; set; }
        public string Large { get; set; }
        public string Medium { get; set; }
        public string Thumbnail { get; set; }
        public Client Client { get; set; }
    }
}
