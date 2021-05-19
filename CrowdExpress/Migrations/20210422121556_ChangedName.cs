using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowdExpress.Migrations
{
    public partial class ChangedName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Users_SenderId",
                table: "Transaction");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "Transaction",
                newName: "AgentId");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_SenderId",
                table: "Transaction",
                newName: "IX_Transaction_AgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Users_AgentId",
                table: "Transaction",
                column: "AgentId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Users_AgentId",
                table: "Transaction");

            migrationBuilder.RenameColumn(
                name: "AgentId",
                table: "Transaction",
                newName: "SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_AgentId",
                table: "Transaction",
                newName: "IX_Transaction_SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Users_SenderId",
                table: "Transaction",
                column: "SenderId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
