using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {/*
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "journey",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Origin = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Destination = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "transport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FlightCarrier = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FlightNumber = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "flight",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TransportId = table.Column<int>(type: "int", nullable: false),
                    Origin = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Destination = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "fk_Flight_Transport",
                        column: x => x.TransportId,
                        principalTable: "transport",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "journeyflight",
                columns: table => new
                {
                    Flight_Id = table.Column<int>(type: "int", nullable: false),
                    Journey_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Flight_Id);
                    table.ForeignKey(
                        name: "fk_JourneyFlight_Flight1",
                        column: x => x.Flight_Id,
                        principalTable: "flight",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_JourneyFlight_Journey1",
                        column: x => x.Journey_Id,
                        principalTable: "journey",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "fk_Flight_Transport_idx",
                table: "flight",
                column: "TransportId");

            migrationBuilder.CreateIndex(
                name: "fk_JourneyFlight_Flight1_idx",
                table: "journeyflight",
                column: "Flight_Id");

            migrationBuilder.CreateIndex(
                name: "fk_JourneyFlight_Journey1_idx",
                table: "journeyflight",
                column: "Journey_Id");
        */}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
/*             migrationBuilder.DropTable(
                name: "journeyflight");

            migrationBuilder.DropTable(
                name: "flight");

            migrationBuilder.DropTable(
                name: "journey");

            migrationBuilder.DropTable(
                name: "transport"); */
        }
    }
}
