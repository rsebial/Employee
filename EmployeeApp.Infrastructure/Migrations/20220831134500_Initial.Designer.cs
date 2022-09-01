﻿// <auto-generated />
using System;
using EmployeeApp.Infrastructure.MySQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeeApp.Infrastructure.Migrations
{
    [DbContext(typeof(EmployeeContext))]
    [Migration("20220831134500_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EmployeeApp.Domain.Models.Employee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Employee", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Caffé Americano",
                            Quantity = 10L,
                            Type = "Americanos"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Veranda Blend",
                            Quantity = 10L,
                            Type = "Brewed Employees"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Caffé Misto",
                            Quantity = 10L,
                            Type = "Brewed Employees"
                        },
                        new
                        {
                            Id = 4L,
                            Name = "Cappuccino",
                            Quantity = 10L,
                            Type = "Cappuccinos"
                        },
                        new
                        {
                            Id = 5L,
                            Name = "Espresso",
                            Quantity = 10L,
                            Type = "Espresso"
                        },
                        new
                        {
                            Id = 6L,
                            Name = "Flat White",
                            Quantity = 10L,
                            Type = "Flat White"
                        },
                        new
                        {
                            Id = 7L,
                            Name = "Honey Almond milk",
                            Quantity = 10L,
                            Type = "Espresso"
                        },
                        new
                        {
                            Id = 8L,
                            Name = "Pumpkin Spice Latte",
                            Quantity = 10L,
                            Type = "Lattes"
                        },
                        new
                        {
                            Id = 9L,
                            Name = "Caffé Latte",
                            Quantity = 10L,
                            Type = "Lattes"
                        },
                        new
                        {
                            Id = 10L,
                            Name = "Cinnamon Dolce Latte",
                            Quantity = 10L,
                            Type = "Lattes"
                        },
                        new
                        {
                            Id = 11L,
                            Name = "Apple Crisp Oatmilk",
                            Quantity = 10L,
                            Type = "Macchiatos"
                        },
                        new
                        {
                            Id = 12L,
                            Name = "Caramel Macchiato",
                            Quantity = 10L,
                            Type = "Macchiatos"
                        },
                        new
                        {
                            Id = 13L,
                            Name = "Espresso Macchiato",
                            Quantity = 10L,
                            Type = "Macchiatos"
                        },
                        new
                        {
                            Id = 14L,
                            Name = "Caffé Mocha",
                            Quantity = 10L,
                            Type = "Mochas"
                        },
                        new
                        {
                            Id = 15L,
                            Name = "White Chocolate Mocha",
                            Quantity = 10L,
                            Type = "Mochas"
                        });
                });

            modelBuilder.Entity("EmployeeApp.Domain.Models.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("order", (string)null);
                });

            modelBuilder.Entity("EmployeeApp.Domain.Models.OrderItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("EmployeeId")
                        .HasColumnType("bigint");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("OrderId");

                    b.ToTable("order_item", (string)null);
                });

            modelBuilder.Entity("EmployeeApp.Domain.Models.OrderItem", b =>
                {
                    b.HasOne("EmployeeApp.Domain.Models.Employee", "Employee")
                        .WithMany("Orders")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EmployeeApp.Domain.Models.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("EmployeeApp.Domain.Models.Employee", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("EmployeeApp.Domain.Models.Order", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}