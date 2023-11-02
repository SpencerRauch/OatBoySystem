﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OatBoySystem.Models;

#nullable disable

namespace OatBoySystem.Migrations
{
    [DbContext(typeof(OatBoyContext))]
    [Migration("20231101231824_SecondMigration")]
    partial class SecondMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("OatBoySystem.Models.BakingMaterial", b =>
                {
                    b.Property<int>("BakingMaterialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UnitOfMeasure")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("BakingMaterialId");

                    b.ToTable("BakingMaterials");
                });

            modelBuilder.Entity("OatBoySystem.Models.BakingMaterialStock", b =>
                {
                    b.Property<int>("BakingMaterialStockId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BakingMaterialId")
                        .HasColumnType("int");

                    b.Property<string>("Batch")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateOfManufacture")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("Expiration")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("BakingMaterialStockId");

                    b.HasIndex("BakingMaterialId");

                    b.ToTable("BakingMaterialStock");
                });

            modelBuilder.Entity("OatBoySystem.Models.BakingMaterialStockAdjustment", b =>
                {
                    b.Property<int>("BakingMaterialStockAdjustmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BakingMaterialStockId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("ReasonCode")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("BakingMaterialStockAdjustmentId");

                    b.HasIndex("BakingMaterialStockId");

                    b.ToTable("BakingMaterialStockAdjustments");
                });

            modelBuilder.Entity("OatBoySystem.Models.Batch", b =>
                {
                    b.Property<int>("BatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("BatchId");

                    b.HasIndex("RecipeId");

                    b.ToTable("Batches");
                });

            modelBuilder.Entity("OatBoySystem.Models.BatchBakingMaterialStockAssociation", b =>
                {
                    b.Property<int>("BatchBakingMaterialStockAssociationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BakingMaterialStockId")
                        .HasColumnType("int");

                    b.Property<int>("BatchId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("BatchBakingMaterialStockAssociationId");

                    b.HasIndex("BakingMaterialStockId");

                    b.HasIndex("BatchId");

                    b.ToTable("BatchBakingMaterialStockAssociations");
                });

            modelBuilder.Entity("OatBoySystem.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("OrderNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("Ordered")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OatBoySystem.Models.OrderProduct", b =>
                {
                    b.Property<int>("OrderProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("OrderProductId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("OatBoySystem.Models.OrderProductStockAssociation", b =>
                {
                    b.Property<int>("OrderProductStockAssociationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("OrderProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProductStockId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("OrderProductStockAssociationId");

                    b.HasIndex("OrderProductId");

                    b.HasIndex("ProductStockId");

                    b.ToTable("OrderProductStockAssociations");
                });

            modelBuilder.Entity("OatBoySystem.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.Property<string>("UnitOfMeasure")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ProductId");

                    b.HasIndex("RecipeId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("OatBoySystem.Models.ProductShippingMaterialAssociation", b =>
                {
                    b.Property<int>("ProductShippingMaterialAssociationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("ShippingMaterialId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ProductShippingMaterialAssociationId");

                    b.HasIndex("ProductId");

                    b.HasIndex("ShippingMaterialId");

                    b.ToTable("ProductShippingMaterialAssociations");
                });

            modelBuilder.Entity("OatBoySystem.Models.ProductStock", b =>
                {
                    b.Property<int>("ProductStockId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BatchId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ProductStockId");

                    b.HasIndex("BatchId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductStock");
                });

            modelBuilder.Entity("OatBoySystem.Models.ProductStockAdjustment", b =>
                {
                    b.Property<int>("ProductStockAdjustmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ProductStockId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("ReasonCode")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ProductStockAdjustmentId");

                    b.HasIndex("ProductStockId");

                    b.ToTable("ProductStockAdjustments");
                });

            modelBuilder.Entity("OatBoySystem.Models.Recipe", b =>
                {
                    b.Property<int>("RecipeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("RecipeId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("OatBoySystem.Models.RecipeBakingMaterialAssociation", b =>
                {
                    b.Property<int>("RecipeBakingMaterialAssociationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BakingMaterialId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("RecipeBakingMaterialAssociationId");

                    b.HasIndex("BakingMaterialId");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipeBakingMaterialAssociations");
                });

            modelBuilder.Entity("OatBoySystem.Models.ShippingMaterial", b =>
                {
                    b.Property<int>("ShippingMaterialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UnitOfMeasure")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ShippingMaterialId");

                    b.ToTable("ShippingMaterials");
                });

            modelBuilder.Entity("OatBoySystem.Models.ShippingMaterialStock", b =>
                {
                    b.Property<int>("ShippingMaterialStockId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("ShippingMaterialId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ShippingMaterialStockId");

                    b.HasIndex("ShippingMaterialId");

                    b.ToTable("ShippingMaterialStock");
                });

            modelBuilder.Entity("OatBoySystem.Models.ShippingMaterialStockAdjustment", b =>
                {
                    b.Property<int>("ShippingMaterialStockAdjustmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("ReasonCode")
                        .HasColumnType("int");

                    b.Property<int>("ShippingMaterialStockId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ShippingMaterialStockAdjustmentId");

                    b.HasIndex("ShippingMaterialStockId");

                    b.ToTable("ShippingMaterialStockAdjustments");
                });

            modelBuilder.Entity("OatBoySystem.Models.BakingMaterialStock", b =>
                {
                    b.HasOne("OatBoySystem.Models.BakingMaterial", "BakingMaterial")
                        .WithMany("Stock")
                        .HasForeignKey("BakingMaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BakingMaterial");
                });

            modelBuilder.Entity("OatBoySystem.Models.BakingMaterialStockAdjustment", b =>
                {
                    b.HasOne("OatBoySystem.Models.BakingMaterialStock", "BakingMaterialStock")
                        .WithMany("Adjustments")
                        .HasForeignKey("BakingMaterialStockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BakingMaterialStock");
                });

            modelBuilder.Entity("OatBoySystem.Models.Batch", b =>
                {
                    b.HasOne("OatBoySystem.Models.Recipe", "Recipe")
                        .WithMany("Batches")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("OatBoySystem.Models.BatchBakingMaterialStockAssociation", b =>
                {
                    b.HasOne("OatBoySystem.Models.BakingMaterialStock", "BakingMaterialStock")
                        .WithMany("BatchAssociations")
                        .HasForeignKey("BakingMaterialStockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OatBoySystem.Models.Batch", "Batch")
                        .WithMany("BakingMaterialStockAssociations")
                        .HasForeignKey("BatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BakingMaterialStock");

                    b.Navigation("Batch");
                });

            modelBuilder.Entity("OatBoySystem.Models.OrderProduct", b =>
                {
                    b.HasOne("OatBoySystem.Models.Order", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OatBoySystem.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OatBoySystem.Models.OrderProductStockAssociation", b =>
                {
                    b.HasOne("OatBoySystem.Models.OrderProduct", "OrderProduct")
                        .WithMany("StockAssociations")
                        .HasForeignKey("OrderProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OatBoySystem.Models.ProductStock", "ProductStock")
                        .WithMany("OrderAssociations")
                        .HasForeignKey("ProductStockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderProduct");

                    b.Navigation("ProductStock");
                });

            modelBuilder.Entity("OatBoySystem.Models.Product", b =>
                {
                    b.HasOne("OatBoySystem.Models.Recipe", "Recipe")
                        .WithMany("Products")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("OatBoySystem.Models.ProductShippingMaterialAssociation", b =>
                {
                    b.HasOne("OatBoySystem.Models.Product", "Product")
                        .WithMany("ShippingMaterialAssociations")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OatBoySystem.Models.ShippingMaterial", "ShippingMaterial")
                        .WithMany("ProductAssociations")
                        .HasForeignKey("ShippingMaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ShippingMaterial");
                });

            modelBuilder.Entity("OatBoySystem.Models.ProductStock", b =>
                {
                    b.HasOne("OatBoySystem.Models.Batch", "Batch")
                        .WithMany("ProductStock")
                        .HasForeignKey("BatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OatBoySystem.Models.Product", "Product")
                        .WithMany("Stock")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Batch");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OatBoySystem.Models.ProductStockAdjustment", b =>
                {
                    b.HasOne("OatBoySystem.Models.ProductStock", "ProductStock")
                        .WithMany("Adjustments")
                        .HasForeignKey("ProductStockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductStock");
                });

            modelBuilder.Entity("OatBoySystem.Models.RecipeBakingMaterialAssociation", b =>
                {
                    b.HasOne("OatBoySystem.Models.BakingMaterial", "BakingMaterial")
                        .WithMany("RecipeAssociations")
                        .HasForeignKey("BakingMaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OatBoySystem.Models.Recipe", "Recipe")
                        .WithMany("BakingMaterialAssociations")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BakingMaterial");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("OatBoySystem.Models.ShippingMaterialStock", b =>
                {
                    b.HasOne("OatBoySystem.Models.ShippingMaterial", "ShippingMaterial")
                        .WithMany("Stock")
                        .HasForeignKey("ShippingMaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShippingMaterial");
                });

            modelBuilder.Entity("OatBoySystem.Models.ShippingMaterialStockAdjustment", b =>
                {
                    b.HasOne("OatBoySystem.Models.ShippingMaterialStock", "ShippingMaterialStock")
                        .WithMany("Adjustments")
                        .HasForeignKey("ShippingMaterialStockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShippingMaterialStock");
                });

            modelBuilder.Entity("OatBoySystem.Models.BakingMaterial", b =>
                {
                    b.Navigation("RecipeAssociations");

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("OatBoySystem.Models.BakingMaterialStock", b =>
                {
                    b.Navigation("Adjustments");

                    b.Navigation("BatchAssociations");
                });

            modelBuilder.Entity("OatBoySystem.Models.Batch", b =>
                {
                    b.Navigation("BakingMaterialStockAssociations");

                    b.Navigation("ProductStock");
                });

            modelBuilder.Entity("OatBoySystem.Models.Order", b =>
                {
                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("OatBoySystem.Models.OrderProduct", b =>
                {
                    b.Navigation("StockAssociations");
                });

            modelBuilder.Entity("OatBoySystem.Models.Product", b =>
                {
                    b.Navigation("ShippingMaterialAssociations");

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("OatBoySystem.Models.ProductStock", b =>
                {
                    b.Navigation("Adjustments");

                    b.Navigation("OrderAssociations");
                });

            modelBuilder.Entity("OatBoySystem.Models.Recipe", b =>
                {
                    b.Navigation("BakingMaterialAssociations");

                    b.Navigation("Batches");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("OatBoySystem.Models.ShippingMaterial", b =>
                {
                    b.Navigation("ProductAssociations");

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("OatBoySystem.Models.ShippingMaterialStock", b =>
                {
                    b.Navigation("Adjustments");
                });
#pragma warning restore 612, 618
        }
    }
}