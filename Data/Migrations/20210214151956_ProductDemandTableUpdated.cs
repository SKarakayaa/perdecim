using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Data.Migrations
{
    public partial class ProductDemandTableUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductDemands",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(nullable: false),
                    DemandTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDemands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDemands_DemandTypes_DemandTypeId",
                        column: x => x.DemandTypeId,
                        principalTable: "DemandTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDemands_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 14, 18, 19, 56, 97, DateTimeKind.Local).AddTicks(2474));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 14, 18, 19, 56, 99, DateTimeKind.Local).AddTicks(5123));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 14, 18, 19, 56, 99, DateTimeKind.Local).AddTicks(5150));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 14, 18, 19, 56, 99, DateTimeKind.Local).AddTicks(5154));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 14, 18, 19, 56, 99, DateTimeKind.Local).AddTicks(5158));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 14, 18, 19, 56, 99, DateTimeKind.Local).AddTicks(5162));

            migrationBuilder.InsertData(
                table: "ProductDemands",
                columns: new[] { "Id", "DemandTypeId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 14, 18, 19, 56, 100, DateTimeKind.Local).AddTicks(9830));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 14, 18, 19, 56, 101, DateTimeKind.Local).AddTicks(1252));

            migrationBuilder.CreateIndex(
                name: "IX_ProductDemands_DemandTypeId",
                table: "ProductDemands",
                column: "DemandTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDemands_ProductId",
                table: "ProductDemands",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductDemands");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 14, 18, 17, 32, 312, DateTimeKind.Local).AddTicks(9245));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 14, 18, 17, 32, 315, DateTimeKind.Local).AddTicks(1827));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 14, 18, 17, 32, 315, DateTimeKind.Local).AddTicks(1860));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 14, 18, 17, 32, 315, DateTimeKind.Local).AddTicks(1864));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 14, 18, 17, 32, 315, DateTimeKind.Local).AddTicks(1869));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 14, 18, 17, 32, 315, DateTimeKind.Local).AddTicks(1871));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 14, 18, 17, 32, 316, DateTimeKind.Local).AddTicks(7699));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 14, 18, 17, 32, 316, DateTimeKind.Local).AddTicks(9141));
        }
    }
}
