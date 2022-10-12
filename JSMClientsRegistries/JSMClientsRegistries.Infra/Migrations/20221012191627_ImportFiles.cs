using JSMClientsRegistries.Core.Entities;
using JSMClientsRegistries.Core.Enums;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace JSMClientsRegistries.Infra.Migrations
{
    public partial class ImportFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var clientList = DeserializeClientListJson();
            int i = 0;
            foreach (var client in clientList)
            {
                i++;
                var type = GetType(client.Location.Latitude, client.Location.Longitude);
                var region = GetRegion(client.Location.State);
                var gender = FormatGender(client.Gender);
                var phone = FormatPhoneNumber(client.Phone);
                var cel = FormatPhoneNumber(client.Cel);
                migrationBuilder.Sql($"INSERT INTO Pictures (Id, Large, Medium, Thumbnail) VALUES ('{i}', '{client.Pictures.Large}', '{client.Pictures.Medium}', '{client.Pictures.Thumbnail}');");
                migrationBuilder.Sql($"INSERT INTO Location (Id, Region, Street, City, State, Postcode, Latitude, Longitude, TimezoneOffset, TimezoneDescription) VALUES ('{i}', '{region}', '{client.Location.Street}', '{client.Location.City}', '{client.Location.State}', '{client.Location.Postcode}', '{client.Location.Latitude}', '{client.Location.Longitude}', '{client.Location.TimezoneOffset}', '{client.Location.TimezoneDescription}');");
                migrationBuilder.Sql($"INSERT INTO Clients (Id, Type, Gender, TitleName, FirstName, LastName, Email, DobDate, RegisteredDate, Phone, Cel, IdLocation, IdPictures) VALUES ('{i}', '{type}', '{gender}', '{client.TitleName}', '{client.FirstName}', '{client.LastName}', '{client.Email}', '{client.DobDate}', '{client.RegisteredDate}', '{phone}', '{cel}', '{i}', '{i}');");
            }
        }

        //De JSON file
        private List<Client> DeserializeClientListJson()
        {
            List<Client> clients = null;

            using (StreamReader stream = new StreamReader(@"..\Files\input-backend.json"))
            {
                string jsonFile = stream.ReadToEnd();
                clients = JsonSerializer.Deserialize<List<Client>>(jsonFile);
            }
            return clients;
        }

        
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
                    
                }
            }
            return clients;
        }
        

        //Methods
        private ClientTypeEnum GetType(string longitude, string latitude)
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
                return ClientTypeEnum.Special;
            else if (lat >= minlat && lat <= maxlat &&
                lon >= minlon && lon <= maxlon)
                return ClientTypeEnum.Normal;
            else
                return ClientTypeEnum.Laborious;
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

        private string FormatPhoneNumber(string number)
        {
            number = new string((from c in number where char.IsDigit(c) select c).ToArray());
            number = "+55" + number;

            return number;
        }
    }
}
