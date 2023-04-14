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
    [Migration("20230414184856_Steamroller")]
    partial class Steamroller
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("bidder.Auction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("condition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("currentBid")
                        .HasColumnType("float");

                    b.Property<DateTime>("endTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("itemDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("itemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("startTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("startingBid")
                        .HasColumnType("float");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("winnerId")
                        .HasColumnType("int");

                    b.Property<double>("winningBid")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Auctions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            condition = "New",
                            currentBid = 0.0,
                            endTime = new DateTime(2023, 4, 14, 14, 48, 56, 761, DateTimeKind.Local).AddTicks(8834),
                            image = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/13/African_buffalo_%28Syncerus_caffer_caffer%29_male_with_cattle_egret.jpg/1200px-African_buffalo_%28Syncerus_caffer_caffer%29_male_with_cattle_egret.jpg",
                            itemDescription = "Buffalo",
                            itemName = "Buffalo",
                            startTime = new DateTime(2023, 4, 14, 14, 48, 56, 761, DateTimeKind.Local).AddTicks(8794),
                            startingBid = 15.0,
                            type = "Buffalo",
                            winningBid = 0.0
                        });
                });

            modelBuilder.Entity("bidder.Models.Bid", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("AuctionID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Bids");
                });

            modelBuilder.Entity("bidder.Models.User", b =>
                {
                    b.Property<int>("userID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("userID"), 1L, 1);

                    b.Property<bool>("admin")
                        .HasColumnType("bit");

                    b.Property<bool>("buyer")
                        .HasColumnType("bit");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("passwordConfirm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("seller")
                        .HasColumnType("bit");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("verifiedStatus")
                        .HasColumnType("bit");

                    b.HasKey("userID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            userID = 1,
                            admin = false,
                            buyer = true,
                            email = "buyer@gmail.com",
                            firstName = "buy",
                            lastName = "er",
                            password = "123Password1$",
                            passwordConfirm = "123Password1$",
                            seller = false,
                            username = "buyer",
                            verifiedStatus = true
                        },
                        new
                        {
                            userID = 2,
                            admin = false,
                            buyer = false,
                            email = "seller@gmail.com",
                            firstName = "sel",
                            lastName = "ler",
                            password = "123Password1$",
                            passwordConfirm = "123Password1$",
                            seller = true,
                            username = "seller",
                            verifiedStatus = true
                        },
                        new
                        {
                            userID = 3,
                            admin = true,
                            buyer = true,
                            email = "admin@gmail.com",
                            firstName = "ad",
                            lastName = "min",
                            password = "123Password1$",
                            passwordConfirm = "123Password1$",
                            seller = false,
                            username = "admin",
                            verifiedStatus = true
                        });
                });
#pragma warning restore 612, 618
        }
    }
}