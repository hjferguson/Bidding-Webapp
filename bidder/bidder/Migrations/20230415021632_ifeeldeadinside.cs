using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bidder.Migrations
{
    public partial class ifeeldeadinside : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Auctions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    itemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    itemDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    startingBid = table.Column<double>(type: "float", nullable: false),
                    currentBid = table.Column<double>(type: "float", nullable: false),
                    winningBid = table.Column<double>(type: "float", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Auctions_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_Bids_Auctions_AuctionID",
                        column: x => x.AuctionID,
                        principalTable: "Auctions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bids_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "userID", "admin", "buyer", "email", "firstName", "lastName", "password", "passwordConfirm", "seller", "username", "verifiedStatus" },
                values: new object[] { 1, false, true, "buyer@gmail.com", "buy", "er", "123Password1$", "123Password1$", false, "buyer", true });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "userID", "admin", "buyer", "email", "firstName", "lastName", "password", "passwordConfirm", "seller", "username", "verifiedStatus" },
                values: new object[] { 2, false, false, "seller@gmail.com", "sel", "ler", "123Password1$", "123Password1$", true, "seller", true });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "userID", "admin", "buyer", "email", "firstName", "lastName", "password", "passwordConfirm", "seller", "username", "verifiedStatus" },
                values: new object[] { 3, true, true, "admin@gmail.com", "ad", "min", "123Password1$", "123Password1$", false, "admin", true });

            migrationBuilder.InsertData(
                table: "Auctions",
                columns: new[] { "Id", "CreatorId", "condition", "currentBid", "endTime", "image", "itemDescription", "itemName", "startTime", "startingBid", "type", "winnerId", "winningBid" },
                values: new object[] { 1, 2, "New", 0.0, new DateTime(2023, 4, 14, 22, 16, 31, 587, DateTimeKind.Local).AddTicks(6941), "https://upload.wikimedia.org/wikipedia/commons/thumb/1/13/African_buffalo_%28Syncerus_caffer_caffer%29_male_with_cattle_egret.jpg/1200px-African_buffalo_%28Syncerus_caffer_caffer%29_male_with_cattle_egret.jpg", "Buffalo", "Buffalo", new DateTime(2023, 4, 14, 22, 16, 31, 587, DateTimeKind.Local).AddTicks(6903), 15.0, "Buffalo", null, 15.0 });

            migrationBuilder.InsertData(
                table: "Auctions",
                columns: new[] { "Id", "CreatorId", "condition", "currentBid", "endTime", "image", "itemDescription", "itemName", "startTime", "startingBid", "type", "winnerId", "winningBid" },
                values: new object[] { 2, 2, "New", 15.0, new DateTime(2023, 4, 14, 22, 21, 31, 587, DateTimeKind.Local).AddTicks(6948), "https://static.displate.com/857x1200/displate/2020-11-13/82125307287b2e5a94c8cfb31e6ecc79_27a3dc812489a692d79f3ef7d63be919.jpg", "Signed by us", "Mark Ruffalo Signed Poster", new DateTime(2023, 4, 14, 22, 16, 31, 587, DateTimeKind.Local).AddTicks(6946), 15.0, "Collectibe", null, 0.0 });

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_CreatorId",
                table: "Auctions",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_AuctionID",
                table: "Bids",
                column: "AuctionID");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_UserID",
                table: "Bids",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_userID",
                table: "Review",
                column: "userID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bids");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Auctions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
