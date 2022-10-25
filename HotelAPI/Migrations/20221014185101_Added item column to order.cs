using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelAPI.Migrations
{
    public partial class Addeditemcolumntoorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HotelViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomName = table.Column<string>(nullable: true),
                    RoomType = table.Column<string>(nullable: true),
                    RoomDes = table.Column<string>(nullable: true),
                    RoomPrice = table.Column<int>(nullable: false),
                    RoomImg = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CartItemViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Days = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    RoomId = table.Column<int>(nullable: true),
                    OrderModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItemViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItemViewModel_Orders_OrderModelId",
                        column: x => x.OrderModelId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartItemViewModel_HotelViewModel_RoomId",
                        column: x => x.RoomId,
                        principalTable: "HotelViewModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItemViewModel_OrderModelId",
                table: "CartItemViewModel",
                column: "OrderModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItemViewModel_RoomId",
                table: "CartItemViewModel",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItemViewModel");

            migrationBuilder.DropTable(
                name: "HotelViewModel");
        }
    }
}
