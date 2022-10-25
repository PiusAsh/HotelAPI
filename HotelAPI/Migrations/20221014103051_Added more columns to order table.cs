using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelAPI.Migrations
{
    public partial class Addedmorecolumnstoordertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User_Id",
                table: "Created Orders");

            migrationBuilder.AddColumn<DateTime>(
                name: "Book_Date",
                table: "Created Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Guest_Name",
                table: "Created Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Created Orders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Total_Price",
                table: "Created Orders",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Book_Date",
                table: "Created Orders");

            migrationBuilder.DropColumn(
                name: "Guest_Name",
                table: "Created Orders");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Created Orders");

            migrationBuilder.DropColumn(
                name: "Total_Price",
                table: "Created Orders");

            migrationBuilder.AddColumn<int>(
                name: "User_Id",
                table: "Created Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
