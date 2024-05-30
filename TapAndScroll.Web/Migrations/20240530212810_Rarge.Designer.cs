﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TapAndScroll.Core;

#nullable disable

namespace TapAndScroll.Web.Migrations
{
    [DbContext(typeof(TapAndScrollDbContext))]
    [Migration("20240530212810_Rarge")]
    partial class Rarge
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TapAndScroll.Core.Models.AdditionalParameters", b =>
                {
                    b.Property<int>("IdAAdditionalParameters")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAAdditionalParameters"));

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("IdAAdditionalParameters");

                    b.HasIndex("ProductId");

                    b.ToTable("AdditionalParameters");
                });

            modelBuilder.Entity("TapAndScroll.Core.Models.AdditionalParametersCategory", b =>
                {
                    b.Property<int>("IdAdditionalParameters")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAdditionalParameters"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<bool>("IsRange")
                        .HasColumnType("bit");

                    b.Property<string>("NameParameters")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SlugParameters")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdAdditionalParameters");

                    b.HasIndex("CategoryId");

                    b.ToTable("AdditionalParametersCategory");
                });

            modelBuilder.Entity("TapAndScroll.Core.Models.Basket", b =>
                {
                    b.Property<int>("IdBasket")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdBasket"));

                    b.Property<int?>("ProductIdProduct")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(12, 2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("IdBasket");

                    b.HasIndex("ProductIdProduct");

                    b.HasIndex("UserId");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("TapAndScroll.Core.Models.BasketProduct", b =>
                {
                    b.Property<int>("IdBasketProduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdBasketProduct"));

                    b.Property<int?>("BasketIdBasket")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("IdBasketProduct");

                    b.HasIndex("BasketIdBasket");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("BasketsProduct");
                });

            modelBuilder.Entity("TapAndScroll.Core.Models.Category", b =>
                {
                    b.Property<int>("IdCategory")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCategory"));

                    b.Property<string>("CategoryDescription")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("IdCategory");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TapAndScroll.Core.Models.Favorites", b =>
                {
                    b.Property<int>("IdFavorites")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFavorites"));

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductIdProduct")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("IdFavorites");

                    b.HasIndex("ProductId");

                    b.HasIndex("ProductIdProduct");

                    b.HasIndex("UserId");

                    b.ToTable("Favorites");
                });

            modelBuilder.Entity("TapAndScroll.Core.Models.Feedback", b =>
                {
                    b.Property<int>("IdFeedback")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFeedback"));

                    b.Property<string>("BadMoment")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("GoodMoment")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("IdFeedback");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("TapAndScroll.Core.Models.ImgProduct", b =>
                {
                    b.Property<int>("IdImgProduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdImgProduct"));

                    b.Property<string>("ImgPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("IdImgProduct");

                    b.HasIndex("ProductId");

                    b.ToTable("ImgProducts");
                });

            modelBuilder.Entity("TapAndScroll.Core.Models.Order", b =>
                {
                    b.Property<int>("IdOrder")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdOrder"));

                    b.Property<bool>("IsReady")
                        .HasColumnType("bit");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(12, 2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("IdOrder");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("TapAndScroll.Core.Models.OrderProduct", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("IdOrderProduct")
                        .HasColumnType("int");

                    b.Property<int?>("ProductIdProduct")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.HasIndex("ProductIdProduct");

                    b.ToTable("OrdersProduct");
                });

            modelBuilder.Entity("TapAndScroll.Core.Models.Product", b =>
                {
                    b.Property<int>("IdProduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProduct"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<int?>("OrderIdOrder")
                        .HasColumnType("int");

                    b.Property<int>("Page")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("IdProduct");

                    b.HasIndex("CategoryId");

                    b.HasIndex("OrderIdOrder");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("TapAndScroll.Core.Models.Role", b =>
                {
                    b.Property<int>("IdRole")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRole"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("IdRole");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("TapAndScroll.Core.Models.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUser"));

                    b.Property<decimal>("Bonus")
                        .HasColumnType("decimal(12, 2)");

                    b.Property<string>("ConfirmToken")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("HashPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsConfirm")
                        .HasColumnType("bit");

                    b.Property<decimal>("Money")
                        .HasColumnType("decimal(12, 2)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("IdUser");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TapAndScroll.Core.Models.AdditionalParameters", b =>
                {
                    b.HasOne("TapAndScroll.Core.Models.Product", "Product")
                        .WithMany("Parameters")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("TapAndScroll.Core.Models.AdditionalParametersCategory", b =>
                {
                    b.HasOne("TapAndScroll.Core.Models.Category", "Category")
                        .WithMany("AdditionalParametersCategory")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("TapAndScroll.Core.Models.Basket", b =>
                {
                    b.HasOne("TapAndScroll.Core.Models.Product", null)
                        .WithMany("Baskets")
                        .HasForeignKey("ProductIdProduct");

                    b.HasOne("TapAndScroll.Core.Models.User", "User")
                        .WithMany("Baskets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TapAndScroll.Core.Models.BasketProduct", b =>
                {
                    b.HasOne("TapAndScroll.Core.Models.Basket", null)
                        .WithMany("Products")
                        .HasForeignKey("BasketIdBasket");

                    b.HasOne("TapAndScroll.Core.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TapAndScroll.Core.Models.User", "User")
                        .WithMany("BasketProducts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TapAndScroll.Core.Models.Favorites", b =>
                {
                    b.HasOne("TapAndScroll.Core.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TapAndScroll.Core.Models.Product", null)
                        .WithMany("Favorites")
                        .HasForeignKey("ProductIdProduct");

                    b.HasOne("TapAndScroll.Core.Models.User", "User")
                        .WithMany("Favorites")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TapAndScroll.Core.Models.Feedback", b =>
                {
                    b.HasOne("TapAndScroll.Core.Models.Product", "Product")
                        .WithMany("Feedbacks")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TapAndScroll.Core.Models.User", "User")
                        .WithMany("Feedbacks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TapAndScroll.Core.Models.ImgProduct", b =>
                {
                    b.HasOne("TapAndScroll.Core.Models.Product", null)
                        .WithMany("Products")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TapAndScroll.Core.Models.Order", b =>
                {
                    b.HasOne("TapAndScroll.Core.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TapAndScroll.Core.Models.OrderProduct", b =>
                {
                    b.HasOne("TapAndScroll.Core.Models.Order", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TapAndScroll.Core.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TapAndScroll.Core.Models.Product", null)
                        .WithMany("Order")
                        .HasForeignKey("ProductIdProduct");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("TapAndScroll.Core.Models.Product", b =>
                {
                    b.HasOne("TapAndScroll.Core.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TapAndScroll.Core.Models.Order", null)
                        .WithMany("Products")
                        .HasForeignKey("OrderIdOrder");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("TapAndScroll.Core.Models.User", b =>
                {
                    b.HasOne("TapAndScroll.Core.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("TapAndScroll.Core.Models.Basket", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("TapAndScroll.Core.Models.Category", b =>
                {
                    b.Navigation("AdditionalParametersCategory");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("TapAndScroll.Core.Models.Order", b =>
                {
                    b.Navigation("OrderProducts");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("TapAndScroll.Core.Models.Product", b =>
                {
                    b.Navigation("Baskets");

                    b.Navigation("Favorites");

                    b.Navigation("Feedbacks");

                    b.Navigation("Order");

                    b.Navigation("Parameters");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("TapAndScroll.Core.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("TapAndScroll.Core.Models.User", b =>
                {
                    b.Navigation("BasketProducts");

                    b.Navigation("Baskets");

                    b.Navigation("Favorites");

                    b.Navigation("Feedbacks");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
