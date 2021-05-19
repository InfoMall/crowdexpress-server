using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowdExpress.Migrations
{
    public partial class AddedIdCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdCard",
                table: "Users",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdCard",
                table: "Users");
        }
    }
}
