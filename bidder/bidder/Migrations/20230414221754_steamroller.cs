using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bidder.Migrations
{
    public partial class steamroller : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auctions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    itemDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    startingBid = table.Column<double>(type: "float", nullable: false),
                    currentBid = table.Column<double>(type: "float", nullable: false),
                    winningBid = table.Column<double>(type: "float", nullable: false),
                    bidID = table.Column<double>(type: "float", nullable: false),
                    startTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    condition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    winnerId = table.Column<int>(type: "int", nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auctions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bids",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuctionID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bids", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    passwordConfirm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    seller = table.Column<bool>(type: "bit", nullable: false),
                    buyer = table.Column<bool>(type: "bit", nullable: false),
                    admin = table.Column<bool>(type: "bit", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    verifiedStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userID);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reviewer = table.Column<int>(type: "int", nullable: false),
                    SellerId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Review_Users_userID",
                        column: x => x.userID,
                        principalTable: "Users",
                        principalColumn: "userID");
                });

            migrationBuilder.InsertData(
                table: "Auctions",
                columns: new[] { "Id", "bidID", "condition", "currentBid", "endTime", "image", "itemDescription", "itemName", "startTime", "startingBid", "type", "winnerId", "winningBid" },
                values: new object[] { 1, 0.0, "New", 0.0, new DateTime(2023, 4, 14, 18, 17, 53, 745, DateTimeKind.Local).AddTicks(4879), "https://upload.wikimedia.org/wikipedia/commons/thumb/1/13/African_buffalo_%28Syncerus_caffer_caffer%29_male_with_cattle_egret.jpg/1200px-African_buffalo_%28Syncerus_caffer_caffer%29_male_with_cattle_egret.jpg", "Buffalo", "Buffalo", new DateTime(2023, 4, 14, 18, 17, 53, 745, DateTimeKind.Local).AddTicks(4839), 15.0, "Buffalo", null, 0.0 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "userID", "admin", "buyer", "email", "firstName", "lastName", "password", "passwordConfirm", "seller", "username", "verifiedStatus" },
                values: new object[,]
                {
                    { 1, false, true, "buyer@gmail.com", "buy", "er", "123Password1$", "123Password1$", false, "buyer", true },
                    { 2, false, false, "seller@gmail.com", "sel", "ler", "123Password1$", "123Password1$", true, "seller", true },
                    { 3, true, true, "admin@gmail.com", "ad", "min", "123Password1$", "123Password1$", false, "admin", true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Review_userID",
                table: "Review",
                column: "userID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auctions");

            migrationBuilder.DropTable(
                name: "Bids");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
