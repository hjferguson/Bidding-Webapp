using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bidder.Migrations
{
    public partial class bidder : Migration
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
                    //SQL error that was missing columns. Added these columns mimicing the auction class. HF
                    currentBid = table.Column<double>(type:"float", nullable: false),
                    winningBid = table.Column<double>(type: "float", nullable: false),
                    //
                    startTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    condition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auctions", x => x.Id);
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

            migrationBuilder.InsertData(
                table: "Auctions",
                columns: new[] { "Id", "condition", "endTime", "image", "itemDescription", "itemName", "startTime", "startingBid", "type" },
                values: new object[] { 1, "New", new DateTime(2023, 4, 12, 22, 43, 51, 277, DateTimeKind.Local).AddTicks(7705), "https://upload.wikimedia.org/wikipedia/commons/thumb/1/13/African_buffalo_%28Syncerus_caffer_caffer%29_male_with_cattle_egret.jpg/1200px-African_buffalo_%28Syncerus_caffer_caffer%29_male_with_cattle_egret.jpg", "Buffalo", "Buffalo", new DateTime(2023, 4, 12, 22, 43, 51, 277, DateTimeKind.Local).AddTicks(7670), 15.0, "Buffalo" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "userID", "admin", "buyer", "email", "firstName", "lastName", "password", "passwordConfirm", "seller", "username", "verifiedStatus" },
                values: new object[,]
                {
                    { 1, false, true, "buyer@gmail.com", "buy", "er", "123Password1$", "123Password1$", false, "buyer", true },
                    { 2, false, false, "seller@gmail.com", "sel", "ler", "123Password1$", "123Password1$", true, "seller", true },
                    { 3, true, true, "admin@gmail.com", "ad", "min", "123Password1$", "123Password1$", false, "admin", true }
                });
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
