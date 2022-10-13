using JSMClientsRegistries.Core.DTOs;
using JSMClientsRegistries.Core.Enums;
using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace JSMClientsRegistries.Infra.Migrations
{
    public partial class Input : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var clientList = DeserializeClientListJson();
            int i = 0;
            foreach (var client in clientList.Results)
            {
                i++;
                var type = GetType(client.Location.Coordinates.Latitude, client.Location.Coordinates.Longitude);
                var region = GetRegion(client.Location.State);
                var gender = FormatGender(client.Gender);
                var phone = FormatNumberToE164(client.Phone);
                var cel = FormatNumberToE164(client.Cell);
                migrationBuilder.Sql($"INSERT INTO Pictures (Id, Large, Medium, Thumbnail) VALUES ('{i}', '{client.Picture.Large}', '{client.Picture.Medium}', '{client.Picture.Thumbnail}');");
                migrationBuilder.Sql($"INSERT INTO Locations (Id, Region, Street, City, State, Postcode, Latitude, Longitude, TimezoneOffset, TimezoneDescription) VALUES ('{i}', '{region}', '{client.Location.Street}', '{client.Location.City}', '{client.Location.State}', '{client.Location.Postcode}', '{client.Location.Coordinates.Latitude}', '{client.Location.Coordinates.Longitude}', '{client.Location.Timezone.Offset}', '{client.Location.Timezone.Description}');");
                migrationBuilder.Sql($"INSERT INTO Clients (Id, Type, Gender, TitleName, FirstName, LastName, Email, DobDate, RegisteredDate, Phone, Cell, IdLocation, IdPicture) VALUES ('{i}', '{type}', '{gender}', '{client.Name.Title}', '{client.Name.First}', '{client.Name.Last}', '{client.Email}', '{client.Dob.Date}', '{client.Registered.Date}', '{phone}', '{cel}', '{i}', '{i}');");
            }
        }

        //Import JSON file
        private ResultsDTO DeserializeClientListJson()
        {
            ResultsDTO clients = new ResultsDTO();

            using (StreamReader stream = new StreamReader(@"..\Files\input-backend.json"))
            {
                string jsonFile = stream.ReadToEnd();
                clients = JsonSerializer.Deserialize<ResultsDTO>(jsonFile);
            }
            return clients;
        }

        /*
        //Import CSV file
        private List<Client> DeserializeClientListCsv()
        {
            List<Client> clients = null;
            var reader = new StreamReader(File.OpenRead(@"..\Files\input-backend.csv"));
            List<string> clientList = new List<string>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                clientList.Add(values[0]);
                foreach (var column in clientList)
                {
                    Console.WriteLine(column);
                }
            }
            return clients;
        }
        */

        //Methods
        private ClientTypeEnum GetType(string latitude, string longitude)
        {
            decimal.TryParse(longitude.Replace('.', ','), out var lon);
            decimal.TryParse(latitude.Replace('.', ','), out var lat);

            #region Special
            int totalSpecialAreas = 2;
            decimal[,] special = new decimal[totalSpecialAreas, 4];

            #region Limits
            /* Index for reference
             * special[i, 0]: min latitude
             * special[i, 1]: max latitude
             * special[i, 2]: min longitude
             * special[i, 3]: max longitude
             */

            int i = 0;

            //Special Area 001
            special[i, 0] = -15.411580m;
            special[i, 1] = -02.196998m;
            special[i, 2] = -46.361899m;
            special[i, 3] = -34.276938m;
            i++;

            //Special Area 002
            special[i, 0] = -23.966413m;
            special[i, 1] = -19.766959m;
            special[i, 2] = -52.997614m;
            special[i, 3] = -44.428305m;
            i++;
            #endregion

            for (int j = 0; j < i; j++)
            {
                if (lat >= special[j, 0] && lat <= special[j, 1] && lon >= special[j, 2] && lon <= special[j, 3])
                {
                    return ClientTypeEnum.Special;
                }
            }
            #endregion

            #region Normal
            int totalNormalAreas = 1;
            decimal[,] normal = new decimal[totalNormalAreas, 4];

            #region Limits
            /* Index for reference
             * normal[i, 0]: min latitude
             * normal[i, 1]: max latitude
             * normal[i, 2]: min longitude
             * normal[i, 3]: max longitude
             */

            i = 0;

            //Normal Area 001
            normal[i, 0] = -34.016466m;
            normal[i, 1] = -26.155681m;
            normal[i, 2] = -54.777426m;
            normal[i, 3] = -46.603598m;
            i++;
            #endregion

            for (int j = 0; j < i; j++)
            {
                if (lat >= normal[j, 0] && lat <= normal[j, 1] && lon >= normal[j, 2] && lon <= normal[j, 3])
                {
                    return ClientTypeEnum.Normal;
                }
            }
            #endregion

            #region Laborious
            return ClientTypeEnum.Laborious;
            #endregion
        }

        private ClientRegionEnum GetRegion(string state)
        {
            switch (state)
            {
                case "goiás":
                case "mato grosso":
                case "mato grosso do sul":
                case "distrito federal":
                    return ClientRegionEnum.CentroOeste;
                case "acre":
                case "amazonas":
                case "amapá":
                case "pará":
                case "rondônia":
                case "roraima":
                case "tocantins":
                    return ClientRegionEnum.Norte;
                case "alagoas":
                case "bahia":
                case "ceará":
                case "maranhão":
                case "piauí":
                case "pernambuco":
                case "paraíba":
                case "rio grande do norte":
                case "sergipe":
                    return ClientRegionEnum.Nordeste;
                case "paraná":
                case "rio grande do sul":
                case "santa catarina":
                    return ClientRegionEnum.Sul;
                case "espírito santo":
                case "minas gerais":
                case "rio de janeiro":
                case "são paulo":
                    return ClientRegionEnum.Sudeste;
                default:
                    return ClientRegionEnum.Outsider;
            }
        }

        private char FormatGender(string gender)
        {
            return gender[0];
        }

        private string FormatNumberToE164(string number)
        {
            number = new string((from c in number where char.IsDigit(c) select c).ToArray());
            number = "+55" + number;

            return number;
        }

        /*
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }*/
    }
}
