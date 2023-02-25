using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bidder.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    verifiedStatus = table.Column<bool>(type: "bit", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userID);
                });

            migrationBuilder.CreateTable(
                name: "Auctions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    startingBid = table.Column<double>(type: "float", nullable: true),
                    startTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    endTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    sellerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auctions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Auctions_Users_sellerId",
                        column: x => x.sellerId,
                        principalTable: "Users",
                        principalColumn: "userID");
                });

            migrationBuilder.InsertData(
                table: "Auctions",
                columns: new[] { "Id", "endTime", "itemName", "sellerId", "startTime", "startingBid" },
                values: new object[] { 1, null, "Buffalo", null, null, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "userID", "email", "password", "username", "verifiedStatus" },
                values: new object[] { 1, "mikewheeler@gmail.com", "password", "mikeWheeler", false });

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_sellerId",
                table: "Auctions",
                column: "sellerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auctions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
