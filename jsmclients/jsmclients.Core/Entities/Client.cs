using jsmclients.Core.Enums;
using System;

namespace jsmclients.Core.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public ClientTypeEnum Type { get; set; }
        public string Gender { get; set; }
        public string TitleName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DobDate { get; set; }
        public DateTime RegisteredDate { get; set; }
        public string Phone { get; set; }
        public string Cel { get; set; }
        public string Nationality { get; set; }
        public Location Location { get; set; }
        public int IdLocation { get; set; }
        public Pictures Pictures { get; set; }
        public int IdPicture { get; set; }

        public string GetType(string longitude, string latitude)
        {
            #region Limits
            //Special
            decimal minlon1 = -02.196998m;
            decimal minlat1 = -46.361899m;
            decimal maxlon1 = -15.411580m;
            decimal maxlat1 = -34.276938m;

            decimal minlon2 = -19.766959m;
            decimal minlat2 = -52.997614m;
            decimal maxlon2 = -23.966413m;
            decimal maxlat2 = -44.428305m;

            //Normal
            decimal minlon = -26.155681m;
            decimal minlat = -54.777426m;
            decimal maxlon = -34.016466m;
            decimal maxlat = -46.603598m;
            #endregion

            decimal.TryParse(longitude, out var lon);
            decimal.TryParse(latitude, out var lat);

            if ((lat >= minlat1 && lat <= maxlat1 &&
                lon >= minlon1 && lon <= maxlon1) ||
                (lat >= minlat2 && lat <= maxlat2 &&
                lon >= minlon2 && lon <= maxlon2))
                return "special";
            else if (lat >= minlat && lat <= maxlat &&
                lon >= minlon && lon <= maxlon)
                return "normal";
            else
                return "laborious";
        }

        public string GetRegion(string state)
        {
            switch (state)
            {
                case "goiás":
                case "mato grosso":
                case "mato grosso do sul":
                case "distrito federal":
                    return "centro-oeste";
                case "acre":
                case "amazonas":
                case "amapá":
                case "pará":
                case "rondônia":
                case "roraima":
                case "tocantins":
                    return "norte";
                case "alagoas":
                case "bahia":
                case "ceará":
                case "maranhão":
                case "piauí":
                case "pernambuco":
                case "paraíba":
                case "rio grande do norte":
                case "sergipe":
                    return "nordeste";
                case "paraná":
                case "rio grande do sul":
                case "santa catarina":
                    return "sul";
                case "espírito santo":
                case "minas gerais":
                case "rio de janeiro":
                case "são paulo":
                    return "sudeste";
                default:
                    return "outro";
            }
        }
    }
}
