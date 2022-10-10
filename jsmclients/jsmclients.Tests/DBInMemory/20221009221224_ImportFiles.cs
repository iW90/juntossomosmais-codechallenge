using Microsoft.EntityFrameworkCore.Migrations;
using System.Linq;

namespace jsmclients.Infra.Migrations
{
    public partial class ImportFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }


        //Regras de Negócio
        public char SetGender(string gender)
        {
            return gender[0];
        }

        public string SetPhoneNumber(string number)
        {
            number = new string((from c in number where char.IsDigit(c) select c).ToArray());
            number = "+55" + number;

            return number;
        }
    }
}
