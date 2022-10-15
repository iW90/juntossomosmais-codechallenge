using JSMClientsRegistries.Core.DTOs;
using JSMClientsRegistries.Core.Enums;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace JSMClientsRegistries.Infra.Migrations
{
    public partial class Inputs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var clientList = DeserializeClientListCsv();
            //var clientList = DeserializeClientListJson();
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
            ResultsDTO clients = new();

            using (StreamReader stream = new StreamReader(@"..\JSMClientsRegistries.Files\input-backend.json"))
            {
                string jsonFile = stream.ReadToEnd();
                clients = JsonSerializer.Deserialize<ResultsDTO>(jsonFile);
            }
            return clients;
        }


        //Import CSV file
        private ResultsDTO DeserializeClientListCsv()
        {
            string[] csvLines = File.ReadAllLines(@"..\JSMClientsRegistries.Files\input-backend.csv");
            
            var clients = new List<ClientDTO>();

            for (int i = 1; i < csvLines.Length; i++)
            {
                var removequotes = csvLines[i].Replace("\"", "");
                var temp = removequotes.Replace(", ", "|");
                string[] csvData = temp.Split(",");

                clients.Add(new ClientDTO()
                {
                    Gender = csvData[0],
                    Name = new NameDTO()
                    {
                        Title = csvData[1],
                        First = csvData[2],
                        Last = csvData[3]
                    },
                    Location = new LocationDTO()
                    {
                        Street = csvData[4],
                        City = csvData[5],
                        State = csvData[6],
                        Postcode = Int32.Parse(csvData[7]),
                        Coordinates = new CoordinatesDTO()
                        {
                            Latitude = csvData[8],
                            Longitude = csvData[9]
                        },
                        Timezone = new TimezoneDTO()
                        {
                            Offset = csvData[10],
                            Description = csvData[11].Replace("|", ", ")
                        }
                    },
                    Email = csvData[12],
                    Dob = new DobDTO()
                    {
                        Date = csvData[13],
                        Age = Int32.Parse(csvData[14])
                    },
                    Registered = new RegisteredDTO()
                    {
                        Date = csvData[15],
                        Age = Int32.Parse(csvData[16])
                    },
                    Phone = csvData[17],
                    Cell = csvData[18],
                    Picture = new PictureDTO()
                    {
                        Large = csvData[19],
                        Medium = csvData[20],
                        Thumbnail = csvData[21]
                    }
                });
            }

            ResultsDTO results = new ResultsDTO()
            {
                Results = clients
            };

            return results;
        }


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
            special[i, 0] = -46.361899m;
            special[i, 1] = -34.276938m;
            special[i, 2] = -15.411580m;
            special[i, 3] = -02.196998m;
            i++;

            //Special Area 002
            special[i, 0] = -52.997614m;
            special[i, 1] = -44.428305m;
            special[i, 2] = -23.966413m;
            special[i, 3] = -19.766959m;
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
            normal[i, 0] = -54.777426m;
            normal[i, 1] = -46.603598m;
            normal[i, 2] = -34.016466m;
            normal[i, 3] = -26.155681m;
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
