using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bidder.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "endTime", "startTime" },
                values: new object[] { new DateTime(2023, 3, 1, 18, 12, 37, 594, DateTimeKind.Local).AddTicks(1294), new DateTime(2023, 3, 1, 18, 12, 37, 594, DateTimeKind.Local).AddTicks(1260) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "endTime", "startTime" },
                values: new object[] { new DateTime(2023, 3, 1, 1, 6, 17, 401, DateTimeKind.Local).AddTicks(9137), new DateTime(2023, 3, 1, 1, 6, 17, 401, DateTimeKind.Local).AddTicks(9104) });
        }
    }
}
