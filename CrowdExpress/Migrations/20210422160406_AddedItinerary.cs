using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowdExpress.Migrations
{
    public partial class AddedItinerary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Receipient_ReceipientId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Orders_OrderId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipient_Users_InitiatorId",
                table: "Receipient");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Orders_OrderId",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Users_AgentId",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Products_OrderId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Receipient",
                table: "Receipient");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Transaction",
                newName: "Transactions");

            migrationBuilder.RenameTable(
                name: "Receipient",
                newName: "Receipients");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_OrderId",
                table: "Transactions",
                newName: "IX_Transactions_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_AgentId",
                table: "Transactions",
                newName: "IX_Transactions_AgentId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipient_InitiatorId",
                table: "Receipients",
                newName: "IX_Receipients_InitiatorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Receipients",
                table: "Receipients",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Itineraries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itineraries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Itineraries_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Itineraries_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Itineraries_OrderId",
                table: "Itineraries",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Itineraries_ProductId",
                table: "Itineraries",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Receipients_ReceipientId",
                table: "Orders",
                column: "ReceipientId",
                principalTable: "Receipients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipients_Users_InitiatorId",
                table: "Receipients",
                column: "InitiatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Orders_OrderId",
                table: "Transactions",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Users_AgentId",
                table: "Transactions",
                column: "AgentId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Receipients_ReceipientId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipients_Users_InitiatorId",
                table: "Receipients");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Orders_OrderId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Users_AgentId",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "Itineraries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Receipients",
                table: "Receipients");

            migrationBuilder.RenameTable(
                name: "Transactions",
                newName: "Transaction");

            migrationBuilder.RenameTable(
                name: "Receipients",
                newName: "Receipient");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_OrderId",
                table: "Transaction",
                newName: "IX_Transaction_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_AgentId",
                table: "Transaction",
                newName: "IX_Transaction_AgentId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipients_InitiatorId",
                table: "Receipient",
                newName: "IX_Receipient_InitiatorId");

            migrationBuilder.AddColumn<string>(
                name: "OrderId",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Receipient",
                table: "Receipient",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderId",
                table: "Products",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Receipient_ReceipientId",
                table: "Orders",
                column: "ReceipientId",
                principalTable: "Receipient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Orders_OrderId",
                table: "Products",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipient_Users_InitiatorId",
                table: "Receipient",
                column: "InitiatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Orders_OrderId",
                table: "Transaction",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Users_AgentId",
                table: "Transaction",
                column: "AgentId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
