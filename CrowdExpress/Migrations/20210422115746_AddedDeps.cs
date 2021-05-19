using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowdExpress.Migrations
{
    public partial class AddedDeps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_ReceiverId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_SenderId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "OrderEvents");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ReceiverId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_SenderId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "PaymentStatus",
                table: "Orders",
                newName: "OrderStatus");

            migrationBuilder.AddColumn<int>(
                name: "ReceipientId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Receipient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    InitiatorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receipient_Users_InitiatorId",
                        column: x => x.InitiatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PaymentStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SenderId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transaction_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ReceipientId",
                table: "Orders",
                column: "ReceipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipient_InitiatorId",
                table: "Receipient",
                column: "InitiatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_OrderId",
                table: "Transaction",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_SenderId",
                table: "Transaction",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Receipient_ReceipientId",
                table: "Orders",
                column: "ReceipientId",
                principalTable: "Receipient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Receipient_ReceipientId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Receipient");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ReceipientId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ReceipientId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "OrderStatus",
                table: "Orders",
                newName: "PaymentStatus");

            migrationBuilder.AddColumn<string>(
                name: "ReceiverId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrderEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OrderStatus = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderEvents_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ReceiverId",
                table: "Orders",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SenderId",
                table: "Orders",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderEvents_OrderId",
                table: "OrderEvents",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_ReceiverId",
                table: "Orders",
                column: "ReceiverId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_SenderId",
                table: "Orders",
                column: "SenderId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
