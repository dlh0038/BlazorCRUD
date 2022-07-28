﻿// <auto-generated />
using BlazorCRUD.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorCRUD.Server.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    partial class ProductDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.7");

            modelBuilder.Entity("BlazorCRUD.Shared.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1001,
                            Description = "This is a best gaming laptop",
                            Name = "Laptop",
                            Price = 20.02,
                            Quantity = 10
                        },
                        new
                        {
                            Id = 1002,
                            Description = "This is a Office Application",
                            Name = "Microsoft Office",
                            Price = 20.989999999999998,
                            Quantity = 50
                        },
                        new
                        {
                            Id = 1003,
                            Description = "The mouse that works on all surface",
                            Name = "Lazer Mouse",
                            Price = 12.02,
                            Quantity = 20
                        },
                        new
                        {
                            Id = 1004,
                            Description = "To store 256GB of data",
                            Name = "USB Storage",
                            Price = 5.0,
                            Quantity = 20
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
