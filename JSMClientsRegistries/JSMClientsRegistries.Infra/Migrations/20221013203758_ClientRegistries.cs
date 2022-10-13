using Microsoft.EntityFrameworkCore.Migrations;

namespace JSMClientsRegistries.Infra.Migrations
{
    public partial class ClientRegistries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Region = table.Column<int>(type: "INT", nullable: false),
                    Street = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    City = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    State = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Postcode = table.Column<int>(type: "INT", nullable: false),
                    Latitude = table.Column<string>(type: "CHAR(11)", nullable: true),
                    Longitude = table.Column<string>(type: "CHAR(11)", nullable: true),
                    TimezoneOffset = table.Column<string>(type: "CHAR(6)", nullable: true),
                    TimezoneDescription = table.Column<string>(type: "VARCHAR(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Large = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    Medium = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    Thumbnail = table.Column<string>(type: "VARCHAR(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<int>(type: "INT", nullable: false),
                    Gender = table.Column<string>(type: "CHAR(1)", nullable: true),
                    TitleName = table.Column<string>(type: "VARCHAR(10)", nullable: true),
                    FirstName = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    LastName = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Email = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    DobDate = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    RegisteredDate = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    Phone = table.Column<string>(type: "CHAR(20)", nullable: true),
                    Cell = table.Column<string>(type: "CHAR(20)", nullable: true),
                    Nationality = table.Column<string>(type: "CHAR(2)", nullable: true, defaultValue: "BR"),
                    IdLocation = table.Column<int>(type: "INTEGER", nullable: false),
                    IdPicture = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Locations_IdLocation",
                        column: x => x.IdLocation,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clients_Pictures_IdPicture",
                        column: x => x.IdPicture,
                        principalTable: "Pictures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_IdLocation",
                table: "Clients",
                column: "IdLocation",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_IdPicture",
                table: "Clients",
                column: "IdPicture",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Pictures");
        }
    }
}
