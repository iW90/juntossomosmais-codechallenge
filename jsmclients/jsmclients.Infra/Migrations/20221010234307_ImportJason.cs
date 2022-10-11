using jsmclients.Core.Entities;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace jsmclients.Infra.Migrations
{
    public partial class ImportJason
    {
        private static void DeserializeClientListJson()
        {
            List<Client> clients = null;

            using (StreamReader stream = new StreamReader(@".\Files\input.json"))
            {
                string jsonFile = stream.ReadToEnd();
                clients = JsonSerializer.Deserialize<List<Client>>(jsonFile);
            }

        }
    }

}
