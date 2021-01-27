using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UITMBER.Api.Migrations
{
    public partial class OrderDriverRate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DriverRateDate",
                table: "Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DriverRateInfo",
                table: "Orders",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DriverRateDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DriverRateInfo",
                table: "Orders");
        }
    }
}
