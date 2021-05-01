using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class OrderTablesCreated2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_OrderDemands_DemandId",
                table: "OrderDemands",
                column: "DemandId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDemands_DemandTypeId",
                table: "OrderDemands",
                column: "DemandTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDemands_Demands_DemandId",
                table: "OrderDemands",
                column: "DemandId",
                principalTable: "Demands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDemands_DemandTypes_DemandTypeId",
                table: "OrderDemands",
                column: "DemandTypeId",
                principalTable: "DemandTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDemands_Demands_DemandId",
                table: "OrderDemands");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDemands_DemandTypes_DemandTypeId",
                table: "OrderDemands");

            migrationBuilder.DropIndex(
                name: "IX_OrderDemands_DemandId",
                table: "OrderDemands");

            migrationBuilder.DropIndex(
                name: "IX_OrderDemands_DemandTypeId",
                table: "OrderDemands");
        }
    }
}
