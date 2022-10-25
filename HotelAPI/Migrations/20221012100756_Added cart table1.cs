using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelAPI.Migrations
{
    public partial class Addedcarttable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Hotel Rooms_ProductId",
                table: "CartItem");

            migrationBuilder.DropIndex(
                name: "IX_CartItem_ProductId",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "CartItem");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "CartItem",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_RoomId",
                table: "CartItem",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Hotel Rooms_RoomId",
                table: "CartItem",
                column: "RoomId",
                principalTable: "Hotel Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Hotel Rooms_RoomId",
                table: "CartItem");

            migrationBuilder.DropIndex(
                name: "IX_CartItem_RoomId",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "CartItem");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "CartItem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ProductId",
                table: "CartItem",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Hotel Rooms_ProductId",
                table: "CartItem",
                column: "ProductId",
                principalTable: "Hotel Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
