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

        public char SetGender(string gender)
        {
            //Get first character, (f or m)
            return gender[0];
        }

        public string SetPhoneNumber(string number)
        {
            //"(86) 8370-9831" to "+558683709831" (only BR)
            number = new string((from c in number where char.IsDigit(c) select c).ToArray());
            number = "+55" + number;

            return number;
        }
    }
}
