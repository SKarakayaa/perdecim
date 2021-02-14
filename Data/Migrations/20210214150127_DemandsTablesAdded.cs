using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Data.Migrations
{
    public partial class DemandsTablesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DemandTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemandTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Demands",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DemandTypeId = table.Column<int>(nullable: false),
                    ImageName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Demands_DemandTypes_DemandTypeId",
                        column: x => x.DemandTypeId,
                        principalTable: "DemandTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 14, 18, 1, 27, 58, DateTimeKind.Local).AddTicks(980));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 14, 18, 1, 27, 60, DateTimeKind.Local).AddTicks(7085));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 14, 18, 1, 27, 60, DateTimeKind.Local).AddTicks(7118));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 14, 18, 1, 27, 60, DateTimeKind.Local).AddTicks(7121));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 14, 18, 1, 27, 60, DateTimeKind.Local).AddTicks(7127));

            migrationBuilder.InsertData(
                table: "DemandTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Kasa Tipi" },
                    { 2, "Zincir Tipi" },
                    { 3, "Kasa Seçeneği" }
                });

            migrationBuilder.InsertData(
                table: "Demands",
                columns: new[] { "Id", "DemandTypeId", "ImageName", "Name" },
                values: new object[,]
                {
                    { 1, 1, "jumbo_kasa.jpeg", "Jumbo Kasa" },
                    { 2, 1, "metal_kasa.jpeg", "Metal Kasa" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Demands_DemandTypeId",
                table: "Demands",
                column: "DemandTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Demands");

            migrationBuilder.DropTable(
                name: "DemandTypes");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 14, 17, 51, 53, 709, DateTimeKind.Local).AddTicks(2069));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 14, 17, 51, 53, 711, DateTimeKind.Local).AddTicks(7973));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 14, 17, 51, 53, 711, DateTimeKind.Local).AddTicks(8013));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 14, 17, 51, 53, 711, DateTimeKind.Local).AddTicks(8018));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 14, 17, 51, 53, 711, DateTimeKind.Local).AddTicks(8033));
        }
    }
}
