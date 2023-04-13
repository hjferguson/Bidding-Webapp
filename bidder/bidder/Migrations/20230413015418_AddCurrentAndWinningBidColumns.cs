using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bidder.Migrations
{
    public partial class AddCurrentAndWinningBidColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "currentBid",
                table: "Auctions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "winningBid",
                table: "Auctions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "endTime", "startTime" },
                values: new object[] { new DateTime(2023, 4, 12, 21, 54, 17, 997, DateTimeKind.Local).AddTicks(9972), new DateTime(2023, 4, 12, 21, 54, 17, 997, DateTimeKind.Local).AddTicks(9938) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "currentBid",
                table: "Auctions");

            migrationBuilder.DropColumn(
                name: "winningBid",
                table: "Auctions");

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "endTime", "startTime" },
                values: new object[] { new DateTime(2023, 3, 1, 19, 57, 49, 761, DateTimeKind.Local).AddTicks(6766), new DateTime(2023, 3, 1, 19, 57, 49, 761, DateTimeKind.Local).AddTicks(6731) });
        }
    }
}
