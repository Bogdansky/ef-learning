using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfLearning.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "assemblysteps",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    cost = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("assemblysteps_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "partdefinitions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    cost = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("partdefinitions_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "rounds",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    start = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ende = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("rounds_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    start = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ende = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    roundid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("products_pkey", x => x.id);
                    table.ForeignKey(
                        name: "products_roundid_fkey",
                        column: x => x.roundid,
                        principalTable: "rounds",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "stations",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    position = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    roundid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("stations_pkey", x => x.id);
                    table.ForeignKey(
                        name: "stations_roundid_fkey",
                        column: x => x.roundid,
                        principalTable: "rounds",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "parts",
                columns: table => new
                {
                    productid = table.Column<int>(type: "integer", nullable: true),
                    partdefinitionid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "parts_partdefinitionid_fkey",
                        column: x => x.partdefinitionid,
                        principalTable: "partdefinitions",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "parts_productid_fkey",
                        column: x => x.productid,
                        principalTable: "products",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "stationsassemblysteps",
                columns: table => new
                {
                    assemblystepid = table.Column<int>(type: "integer", nullable: true),
                    stationid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "stationsassemblysteps_assemblystepid_fkey",
                        column: x => x.assemblystepid,
                        principalTable: "assemblysteps",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "stationsassemblysteps_stationid_fkey",
                        column: x => x.stationid,
                        principalTable: "stations",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_parts_partdefinitionid",
                table: "parts",
                column: "partdefinitionid");

            migrationBuilder.CreateIndex(
                name: "IX_parts_productid",
                table: "parts",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_products_roundid",
                table: "products",
                column: "roundid");

            migrationBuilder.CreateIndex(
                name: "IX_stations_roundid",
                table: "stations",
                column: "roundid");

            migrationBuilder.CreateIndex(
                name: "IX_stationsassemblysteps_assemblystepid",
                table: "stationsassemblysteps",
                column: "assemblystepid");

            migrationBuilder.CreateIndex(
                name: "IX_stationsassemblysteps_stationid",
                table: "stationsassemblysteps",
                column: "stationid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "parts");

            migrationBuilder.DropTable(
                name: "stationsassemblysteps");

            migrationBuilder.DropTable(
                name: "partdefinitions");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "assemblysteps");

            migrationBuilder.DropTable(
                name: "stations");

            migrationBuilder.DropTable(
                name: "rounds");
        }
    }
}
