﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Order.Service.Data;

#nullable disable

namespace Order.Service.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220622104539_RemoveCity")]
    partial class RemoveCity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Order.Service.Models.FoodOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("CustomerName")
                        .HasColumnType("text");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeliveryAddress")
                        .HasColumnType("text");

                    b.Property<string>("DeliveryCode")
                        .HasColumnType("text");

                    b.Property<string>("FoodCategory")
                        .HasColumnType("text");

                    b.Property<string>("FoodName")
                        .HasColumnType("text");

                    b.Property<string>("RestaurantAddress")
                        .HasColumnType("text");

                    b.Property<string>("RestaurantName")
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<string>("Telephone")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("FoodOrders");
                });

            modelBuilder.Entity("Order.Service.Models.OrderStreamingConnection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Company")
                        .HasColumnType("text");

                    b.Property<string>("ConnectionPassword")
                        .HasColumnType("text");

                    b.Property<string>("RestaurantName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("OrderStreamingConnections");
                });
#pragma warning restore 612, 618
        }
    }
}
