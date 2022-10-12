using JSMClientsRegistries.Core.Enums;
using System;

namespace JSMClientsRegistries.Core.Entities
{
    public class Client
    {
        public int Id { get; private set; }
        public ClientTypeEnum Type { get; private set; }
        public string Gender { get; private set; }
        public string TitleName { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public DateTime DobDate { get; private set; }
        public DateTime RegisteredDate { get; private set; }
        public string Phone { get; private set; }
        public string Cel { get; private set; }
        public string Nationality { get; private set; }
        public Location Location { get; private set; }
        public int IdLocation { get; private set; }
        public Pictures Pictures { get; private set; }
        public int IdPicture { get; private set; }
    }
}
