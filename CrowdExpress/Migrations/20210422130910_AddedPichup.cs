using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowdExpress.Migrations
{
    public partial class AddedPichup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "Orders",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Pickup",
                table: "Orders",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Destination",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Pickup",
                table: "Orders");
        }
    }
}
