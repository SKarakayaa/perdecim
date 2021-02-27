using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class DemandPriceAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Demands",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 27, 12, 3, 48, 935, DateTimeKind.Local).AddTicks(8751));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 27, 12, 3, 48, 939, DateTimeKind.Local).AddTicks(7463));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 27, 12, 3, 48, 939, DateTimeKind.Local).AddTicks(7540));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 27, 12, 3, 48, 939, DateTimeKind.Local).AddTicks(7547));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 27, 12, 3, 48, 939, DateTimeKind.Local).AddTicks(7553));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 27, 12, 3, 48, 939, DateTimeKind.Local).AddTicks(7560));

            migrationBuilder.UpdateData(
                table: "Demands",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 5.0m);

            migrationBuilder.UpdateData(
                table: "Demands",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 10.0m);

            migrationBuilder.InsertData(
                table: "Demands",
                columns: new[] { "Id", "DemandTypeId", "ImageName", "Name", "Price" },
                values: new object[,]
                {
                    { 3, 2, "metal_zincir.jpeg", "Metal Zincir", 0m },
                    { 4, 2, "plasti_zincir.jpeg", "Plastik Zincir", 0m }
                });

            migrationBuilder.InsertData(
                table: "ProductDemands",
                columns: new[] { "Id", "DemandTypeId", "ProductId" },
                values: new object[] { 3, 2, 2 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 27, 12, 3, 48, 942, DateTimeKind.Local).AddTicks(3847));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 27, 12, 3, 48, 942, DateTimeKind.Local).AddTicks(6327));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Demands",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Demands",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductDemands",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Demands");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 14, 20, 33, 27, 498, DateTimeKind.Local).AddTicks(2549));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 14, 20, 33, 27, 503, DateTimeKind.Local).AddTicks(5245));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 14, 20, 33, 27, 503, DateTimeKind.Local).AddTicks(5319));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 14, 20, 33, 27, 503, DateTimeKind.Local).AddTicks(5328));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 14, 20, 33, 27, 503, DateTimeKind.Local).AddTicks(5337));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 14, 20, 33, 27, 503, DateTimeKind.Local).AddTicks(5344));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 14, 20, 33, 27, 507, DateTimeKind.Local).AddTicks(8458));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 14, 20, 33, 27, 508, DateTimeKind.Local).AddTicks(1070));
        }
    }
}
