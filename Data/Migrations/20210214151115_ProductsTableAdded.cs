using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Data.Migrations
{
    public partial class ProductsTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryId = table.Column<int>(nullable: false),
                    BrandId = table.Column<int>(nullable: false),
                    ColorId = table.Column<int>(nullable: false),
                    DiscountRate = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsNew = table.Column<bool>(nullable: false),
                    InStock = table.Column<bool>(nullable: false),
                    Money = table.Column<decimal>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Matmazel" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 14, 18, 11, 14, 631, DateTimeKind.Local).AddTicks(2801));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 14, 18, 11, 14, 633, DateTimeKind.Local).AddTicks(7518));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 14, 18, 11, 14, 633, DateTimeKind.Local).AddTicks(7556));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 14, 18, 11, 14, 633, DateTimeKind.Local).AddTicks(7560));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 14, 18, 11, 14, 633, DateTimeKind.Local).AddTicks(7570));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Name", "ParentId" },
                values: new object[] { 6, new DateTime(2021, 2, 14, 18, 11, 14, 633, DateTimeKind.Local).AddTicks(7572), "Zebra Perde", 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "ColorId", "CreatedAt", "Description", "DiscountRate", "InStock", "IsNew", "Money", "Name" },
                values: new object[,]
                {
                    { 1, 4, 6, 1, new DateTime(2021, 2, 14, 18, 11, 14, 635, DateTimeKind.Local).AddTicks(1696), "Zebra Stor Perde", 0, true, true, 65.00m, "Yıldız Desen Baskılı Zebra Stor Perde" },
                    { 2, 4, 6, 2, new DateTime(2021, 2, 14, 18, 11, 14, 635, DateTimeKind.Local).AddTicks(3484), "Zebra Stor Perde", 20, true, false, 65.00m, "Jakarlı Zebra Stop Perde Su Yolu" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

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
        }
    }
}
