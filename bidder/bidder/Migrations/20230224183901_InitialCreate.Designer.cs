﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using bidder.Data;

#nullable disable

namespace bidder.Migrations
{
    [DbContext(typeof(SiteContext))]
    [Migration("20230224183901_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("bidder.Auction", b =>
                {
                    b.Property<int>("auctionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("auctionID"));

                    b.Property<DateTime?>("auctionEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("auctionStart")
                        .HasColumnType("datetime2");

                    b.Property<string>("category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("condition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("itemDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("itemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("reservePrice")
                        .HasColumnType("float");

                    b.Property<int?>("sellerID")
                        .HasColumnType("int");

                    b.Property<double>("startingBid")
                        .HasColumnType("float");

                    b.HasKey("auctionID");

                    b.HasIndex("sellerID");

                    b.ToTable("Auctions");

                    b.HasData(
                        new
                        {
                            auctionID = 1,
                            itemName = "Buffalo",
                            sellerID = 1,
                            startingBid = 0.0
                        });
                });

            modelBuilder.Entity("bidder.Models.User", b =>
                {
                    b.Property<int?>("userID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("userID"));

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("verifiedStatus")
                        .HasColumnType("bit");

                    b.HasKey("userID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            userID = 1,
                            email = "mikewheeler@gmail.com",
                            password = "password",
                            username = "mikeWheeler",
                            verifiedStatus = false
                        });
                });

            modelBuilder.Entity("bidder.Auction", b =>
                {
                    b.HasOne("bidder.Models.User", "seller")
                        .WithMany()
                        .HasForeignKey("sellerID");

                    b.Navigation("seller");
                });
#pragma warning restore 612, 618
        }
    }
}