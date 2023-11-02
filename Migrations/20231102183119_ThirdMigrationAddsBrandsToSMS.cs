using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OatBoySystem.Migrations
{
    public partial class ThirdMigrationAddsBrandsToSMS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "ShippingMaterialStock",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "ShippingMaterialStock");
        }
    }
}
