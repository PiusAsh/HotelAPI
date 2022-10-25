using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelAPI.Migrations
{
    public partial class AddedisIsAdminColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Status",
                table: "Created Orders");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Created Orders");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "Registered Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Room_Id",
                table: "Created Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "User_Id",
                table: "Created Orders",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "Registered Users");

            migrationBuilder.DropColumn(
                name: "Room_Id",
                table: "Created Orders");

            migrationBuilder.DropColumn(
                name: "User_Id",
                table: "Created Orders");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "Created Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Created Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Created Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: true),
                    RoomId = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_CartItem_Hotel Rooms_RoomId",
                        column: x => x.RoomId,
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
                name: "IX_CartItem_RoomId",
                table: "CartItem",
                column: "RoomId");

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
    }
}
