using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelAPI.Migrations
{
    public partial class Addedcarttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Created Orders");

            migrationBuilder.DropColumn(
                name: "BookDate",
                table: "Created Orders");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Created Orders");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Created Orders");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Created Orders");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Created Orders");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Created Orders");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Created Orders");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Created Orders");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "Created Orders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Created Orders",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cart_Registered Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Registered Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: true),
                    CartId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItem_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartItem_Hotel Rooms_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Hotel Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Created Orders_CartId",
                table: "Created Orders",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Created Orders_UserId",
                table: "Created Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_UserId",
                table: "Cart",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_CartId",
                table: "CartItem",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ProductId",
                table: "CartItem",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Created Orders_Cart_CartId",
                table: "Created Orders",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Created Orders_Registered Users_UserId",
                table: "Created Orders",
                column: "UserId",
                principalTable: "Registered Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Created Orders_Cart_CartId",
                table: "Created Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Created Orders_Registered Users_UserId",
                table: "Created Orders");

            migrationBuilder.DropTable(
                name: "CartItem");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Created Orders_CartId",
                table: "Created Orders");

            migrationBuilder.DropIndex(
                name: "IX_Created Orders_UserId",
                table: "Created Orders");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Created Orders");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Created Orders");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Created Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BookDate",
                table: "Created Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Created Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Created Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Created Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Created Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentId",
                table: "Created Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Created Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalPrice",
                table: "Created Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
