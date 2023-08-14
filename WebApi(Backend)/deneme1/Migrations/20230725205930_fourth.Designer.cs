﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using deneme1.Models;

#nullable disable

namespace deneme1.Migrations
{
    [DbContext(typeof(PersonContext))]
    [Migration("20230725205930_fourth")]
    partial class fourth
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("deneme1.Models.Dask", b =>
                {
                    b.Property<int>("DaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DaskId"));

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Il")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ilce")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("PolicyId")
                        .HasColumnType("int");

                    b.Property<double>("Prim")
                        .HasColumnType("float");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TanzimTarihi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("VadeBaslangic")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("VadeBitis")
                        .HasColumnType("datetime2");

                    b.HasKey("DaskId");

                    b.HasIndex("PersonId");

                    b.HasIndex("ProductId");

                    b.ToTable("Dasks");
                });

            modelBuilder.Entity("deneme1.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"));

                    b.Property<string>("Adi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DogumTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("KimlikNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyadi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("deneme1.Models.Police", b =>
                {
                    b.Property<int>("PoliceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PoliceId"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PoliceNum")
                        .HasColumnType("int");

                    b.Property<string>("PoliceType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Prim")
                        .HasColumnType("float");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("PoliceId");

                    b.ToTable("Polices");
                });

            modelBuilder.Entity("deneme1.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("deneme1.Models.Dask", b =>
                {
                    b.HasOne("deneme1.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("deneme1.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");

                    b.Navigation("Product");
                });
#pragma warning restore 612, 618
        }
    }
}
