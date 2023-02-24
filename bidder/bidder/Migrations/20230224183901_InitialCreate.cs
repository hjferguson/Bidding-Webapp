using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bidder.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
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
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    verifiedStatus = table.Column<bool>(type: "bit", nullable: true),
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
                    auctionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    itemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    startingBid = table.Column<double>(type: "float", nullable: false),
                    reservePrice = table.Column<double>(type: "float", nullable: true),
                    auctionStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    auctionEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    condition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sellerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auctions", x => x.auctionID);
                    table.ForeignKey(
                        name: "FK_Auctions_Users_sellerID",
                        column: x => x.sellerID,
                        principalTable: "Users",
                        principalColumn: "userID");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "userID", "email", "firstName", "lastName", "password", "username", "verifiedStatus" },
                values: new object[] { 1, "mikewheeler@gmail.com", null, null, "password", "mikeWheeler", false });

            migrationBuilder.InsertData(
                table: "Auctions",
                columns: new[] { "auctionID", "auctionEnd", "auctionStart", "category", "condition", "itemDescription", "itemName", "reservePrice", "sellerID", "startingBid" },
                values: new object[] { 1, null, null, null, null, null, "Buffalo", null, 1, 0.0 });

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_sellerID",
                table: "Auctions",
                column: "sellerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auctions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
