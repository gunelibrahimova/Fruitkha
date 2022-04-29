using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class Salammmmm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checks_Products_ProductId",
                table: "Checks");

            migrationBuilder.DropIndex(
                name: "IX_Checks_ProductId",
                table: "Checks");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Checks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Checks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Checks_ProductId",
                table: "Checks",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Checks_Products_ProductId",
                table: "Checks",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
