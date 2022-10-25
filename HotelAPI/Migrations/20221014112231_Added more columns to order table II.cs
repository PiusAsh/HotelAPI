using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelAPI.Migrations
{
    public partial class AddedmorecolumnstoordertableII : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Guest_Name",
                table: "Orders");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "User_Id",
                table: "Orders",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "User_Id",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "Guest_Name",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
