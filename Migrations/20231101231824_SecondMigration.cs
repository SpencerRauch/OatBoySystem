using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OatBoySystem.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductStockAssociations_Products_ProductId",
                table: "OrderProductStockAssociations");

            migrationBuilder.DropIndex(
                name: "IX_OrderProductStockAssociations_ProductId",
                table: "OrderProductStockAssociations");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "OrderProductStockAssociations");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "BakingMaterialStock",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "BakingMaterialStock");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "OrderProductStockAssociations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderProductStockAssociations_ProductId",
                table: "OrderProductStockAssociations",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProductStockAssociations_Products_ProductId",
                table: "OrderProductStockAssociations",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId");
        }
    }
}
