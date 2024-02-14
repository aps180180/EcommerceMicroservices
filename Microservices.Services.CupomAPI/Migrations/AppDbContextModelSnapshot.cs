﻿// <auto-generated />
using System;
using Microservices.Services.CupomAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Microservices.Services.CupomAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microservices.Services.CupomAPI.Models.Coupon", b =>
                {
                    b.Property<int>("CouponId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CouponId"));

                    b.Property<string>("CouponCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("CouponCode");

                    b.Property<decimal>("DiscountAmount")
                        .HasColumnType("Decimal(18,2)")
                        .HasColumnName("DiscountAmount");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("Datetime")
                        .HasColumnName("LastUpdated");

                    b.Property<int>("MinAmount")
                        .HasColumnType("int")
                        .HasColumnName("MinAmount");

                    b.HasKey("CouponId");

                    b.ToTable("Coupon", (string)null);

                    b.HasData(
                        new
                        {
                            CouponId = 1,
                            CouponCode = "10OFF",
                            DiscountAmount = 10m,
                            MinAmount = 20
                        },
                        new
                        {
                            CouponId = 2,
                            CouponCode = "20OFF",
                            DiscountAmount = 20m,
                            MinAmount = 20
                        },
                        new
                        {
                            CouponId = 3,
                            CouponCode = "40FF",
                            DiscountAmount = 40m,
                            MinAmount = 40
                        });
                });
#pragma warning restore 612, 618
        }
    }
}