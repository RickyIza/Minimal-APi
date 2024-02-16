﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sol.Galaxy.Data.Contexts;

#nullable disable

namespace Sol.Galaxy.Data.Migrations
{
    [DbContext(typeof(VentasContext))]
    [Migration("20240213153055_Migration03")]
    partial class Migration03
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Sol.Galaxy.Data.Entities.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer", "DBO");
                });

            modelBuilder.Entity("Sol.Galaxy.Data.Entities.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(12,2)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Inovoice", "DBO");
                });

            modelBuilder.Entity("Sol.Galaxy.Data.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProductCode");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("ProductDescripcion");

                    b.HasKey("ProductId");

                    b.ToTable("Product", "DBO");
                });

            modelBuilder.Entity("Sol.Galaxy.Data.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("UserPassword")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("UserRol")
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("UserId");

                    b.ToTable("User", "DBO");
                });

            modelBuilder.Entity("Sol.Galaxy.Data.Entities.Invoice", b =>
                {
                    b.HasOne("Sol.Galaxy.Data.Entities.Customer", "Customer")
                        .WithMany("Invoices")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Sol.Galaxy.Data.Entities.Customer", b =>
                {
                    b.Navigation("Invoices");
                });
#pragma warning restore 612, 618
        }
    }
}
