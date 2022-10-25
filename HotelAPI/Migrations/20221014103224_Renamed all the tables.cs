using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelAPI.Migrations
{
    public partial class Renamedallthetables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Registered Users",
                table: "Registered Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hotel Rooms",
                table: "Hotel Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Created Orders",
                table: "Created Orders");

            migrationBuilder.RenameTable(
                name: "Registered Users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Hotel Rooms",
                newName: "Rooms");

            migrationBuilder.RenameTable(
                name: "Created Orders",
                newName: "Orders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Registered Users");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "Hotel Rooms");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Created Orders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Registered Users",
                table: "Registered Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hotel Rooms",
                table: "Hotel Rooms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Created Orders",
                table: "Created Orders",
                column: "Id");
        }
    }
}
