using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JSMClientsRegistries.Infra.Migrations
{
    public partial class ClientRegistries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Region = table.Column<int>(type: "INTEGER", nullable: false),
                    Street = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    City = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    State = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Postcode = table.Column<int>(type: "INT", nullable: false),
                    Latitude = table.Column<decimal>(type: "CHAR(11)", nullable: false),
                    Longitude = table.Column<decimal>(type: "CHAR(11)", nullable: false),
                    TimezoneOffset = table.Column<string>(type: "CHAR(6)", nullable: true),
                    TimezoneDescription = table.Column<string>(type: "VARCHAR(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
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
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Gender = table.Column<string>(type: "CHAR(1)", nullable: true),
                    TitleName = table.Column<string>(type: "VARCHAR(10)", nullable: true),
                    FirstName = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    LastName = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Email = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    DobDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    RegisteredDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Phone = table.Column<string>(type: "CHAR(20)", nullable: true),
                    Cel = table.Column<string>(type: "CHAR(20)", nullable: true),
                    Nationality = table.Column<string>(type: "CHAR(2)", nullable: true, defaultValue: "BR"),
                    IdLocation = table.Column<int>(type: "INTEGER", nullable: false),
                    IdPicture = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Client_Location_IdLocation",
                        column: x => x.IdLocation,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Client_Pictures_IdPicture",
                        column: x => x.IdPicture,
                        principalTable: "Pictures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_IdLocation",
                table: "Client",
                column: "IdLocation",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Client_IdPicture",
                table: "Client",
                column: "IdPicture",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Pictures");
        }
    }
}
