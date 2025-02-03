﻿// <auto-generated />
using System;
using Mailo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Mailoo.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250203025826_iii")]
    partial class iii
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Mailo.Models.Contact", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("userId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("userId");

                    b.ToTable("Contact", (string)null);
                });

            modelBuilder.Entity("Mailo.Models.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<double>("DeliveryFee")
                        .HasColumnType("float");

                    b.Property<int?>("EmpID")
                        .HasColumnType("int");

                    b.Property<double>("FinalPrice")
                        .HasColumnType("float");

                    b.Property<string>("OrderAddress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("OrderPrice")
                        .HasColumnType("float");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.Property<int?>("PromoCodeId")
                        .HasColumnType("int");

                    b.Property<string>("PromoCodeUsed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalPrice")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("float")
                        .HasComputedColumnSql("[OrderPrice] + [DeliveryFee]");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("EmpID");

                    b.HasIndex("PromoCodeId");

                    b.HasIndex("UserID");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("Mailo.Models.OrderProduct", b =>
                {
                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("VariantID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderID", "ProductID", "VariantID");

                    b.HasIndex("ProductID");

                    b.HasIndex("VariantID");

                    b.ToTable("OrderProduct", (string)null);
                });

            modelBuilder.Entity("Mailo.Models.Payment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("PaymentStatus")
                        .HasColumnType("int");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.HasIndex("UserID");

                    b.ToTable("Payment", (string)null);
                });

            modelBuilder.Entity("Mailo.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("AdditionDate")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Discount")
                        .HasColumnType("float");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("TotalPrice")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("float")
                        .HasComputedColumnSql("[Price]-([Discount]/100)*[Price]");

                    b.Property<byte[]>("dbImage")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("ID");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("Mailo.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("EmailVerificationToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EmailVerificationTokenExpiry")
                        .HasColumnType("datetime2");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("nvarchar(max)")
                        .HasComputedColumnSql("[FName] + ' ' + [LName]");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<int>("Governorate")
                        .HasColumnType("int");

                    b.Property<string>("InstagramLink")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<bool?>("IsEmailVerified")
                        .HasColumnType("bit");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PasswordResetToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("PasswordResetTokenExpiry")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ID");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("User", (string)null);

                    b.UseTptMappingStrategy();

                    b.HasData(
                        new
                        {
                            ID = 2,
                            Address = "Beni-Suef",
                            Email = "mailostoreee@gmail.com",
                            FName = "Mai",
                            Gender = 1,
                            Governorate = 15,
                            InstagramLink = "https://www.instagram.com/mai.assem.123/",
                            LName = "Assem",
                            Password = "MaiiiAsss123#44",
                            PhoneNumber = "01011895030",
                            RegistrationDate = new DateTime(2025, 2, 3, 4, 58, 26, 182, DateTimeKind.Local).AddTicks(2112),
                            UserType = 1,
                            Username = "MaiAssemAdmin123"
                        });
                });

            modelBuilder.Entity("Mailo.Models.Wishlist", b =>
                {
                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<DateTime>("AdditionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("UserID", "ProductID");

                    b.HasIndex("ProductID");

                    b.ToTable("Wishlist", (string)null);
                });

            modelBuilder.Entity("Mailoo.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("Mailoo.Models.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ColorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Color", (string)null);
                });

            modelBuilder.Entity("Mailoo.Models.ProductVariant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ColorId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("SizeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ColorId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SizeId");

                    b.ToTable("ProductVariant", (string)null);
                });

            modelBuilder.Entity("Mailoo.Models.PromoCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("DiscountPercentage")
                        .HasColumnType("float");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("PromoCode", (string)null);
                });

            modelBuilder.Entity("Mailoo.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<byte[]>("dbImage")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Review", (string)null);
                });

            modelBuilder.Entity("Mailoo.Models.Size", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("SizeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Size", (string)null);
                });

            modelBuilder.Entity("Mailo.Models.Employee", b =>
                {
                    b.HasBaseType("Mailo.Models.User");

                    b.Property<DateTime>("HiringDate")
                        .HasColumnType("datetime2");

                    b.ToTable("Employee", (string)null);
                });

            modelBuilder.Entity("Mailo.Models.Contact", b =>
                {
                    b.HasOne("Mailo.Models.User", "user")
                        .WithMany("Message")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("user");
                });

            modelBuilder.Entity("Mailo.Models.Order", b =>
                {
                    b.HasOne("Mailo.Models.Employee", "employee")
                        .WithMany()
                        .HasForeignKey("EmpID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Mailoo.Models.PromoCode", "PromoCode")
                        .WithMany("Orders")
                        .HasForeignKey("PromoCodeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Mailo.Models.User", "user")
                        .WithMany("orders")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("PromoCode");

                    b.Navigation("employee");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Mailo.Models.OrderProduct", b =>
                {
                    b.HasOne("Mailo.Models.Order", "order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Mailo.Models.Product", "product")
                        .WithMany("OrderProducts")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Mailoo.Models.ProductVariant", "Variant")
                        .WithMany("OrderProducts")
                        .HasForeignKey("VariantID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Variant");

                    b.Navigation("order");

                    b.Navigation("product");
                });

            modelBuilder.Entity("Mailo.Models.Payment", b =>
                {
                    b.HasOne("Mailo.Models.Order", "Order")
                        .WithOne("Payment")
                        .HasForeignKey("Mailo.Models.Payment", "OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Mailo.Models.User", "user")
                        .WithMany("payment")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Mailo.Models.Product", b =>
                {
                    b.HasOne("Mailoo.Models.Category", "Categorys")
                        .WithMany("products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Categorys");
                });

            modelBuilder.Entity("Mailo.Models.Wishlist", b =>
                {
                    b.HasOne("Mailo.Models.Product", "product")
                        .WithMany("wishlists")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Mailo.Models.User", "user")
                        .WithMany("wishlist")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("product");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Mailoo.Models.ProductVariant", b =>
                {
                    b.HasOne("Mailoo.Models.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Mailo.Models.Product", "Product")
                        .WithMany("Variants")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Mailoo.Models.Size", "Size")
                        .WithMany()
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Color");

                    b.Navigation("Product");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("Mailoo.Models.Review", b =>
                {
                    b.HasOne("Mailo.Models.Product", "Product")
                        .WithMany("Reviews")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Mailo.Models.Employee", b =>
                {
                    b.HasOne("Mailo.Models.User", null)
                        .WithOne()
                        .HasForeignKey("Mailo.Models.Employee", "ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Mailo.Models.Order", b =>
                {
                    b.Navigation("OrderProducts");

                    b.Navigation("Payment");
                });

            modelBuilder.Entity("Mailo.Models.Product", b =>
                {
                    b.Navigation("OrderProducts");

                    b.Navigation("Reviews");

                    b.Navigation("Variants");

                    b.Navigation("wishlists");
                });

            modelBuilder.Entity("Mailo.Models.User", b =>
                {
                    b.Navigation("Message");

                    b.Navigation("orders");

                    b.Navigation("payment");

                    b.Navigation("wishlist");
                });

            modelBuilder.Entity("Mailoo.Models.Category", b =>
                {
                    b.Navigation("products");
                });

            modelBuilder.Entity("Mailoo.Models.ProductVariant", b =>
                {
                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("Mailoo.Models.PromoCode", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
