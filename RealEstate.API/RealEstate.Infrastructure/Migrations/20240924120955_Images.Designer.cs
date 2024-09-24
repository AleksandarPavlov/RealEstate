﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RealEstate.Infrastructure.Persistance;

#nullable disable

namespace RealEstate.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240924120955_Images")]
    partial class Images
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RealEstate.Infrastructure.Persistance.Entities.Property", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Coordinates")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FloorNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsFurnished")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPremium")
                        .HasColumnType("bit");

                    b.Property<int>("ListingType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NumberOfRooms")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<double>("SizeInMmSquared")
                        .HasColumnType("float");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Property");
                });

            modelBuilder.Entity("RealEstate.Infrastructure.Persistance.Entities.PropertyImage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("PropertyId")
                        .HasColumnType("bigint");

                    b.Property<long?>("PropertyId1")
                        .HasColumnType("bigint");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId")
                        .IsUnique();

                    b.HasIndex("PropertyId1");

                    b.ToTable("PropertyImage");
                });

            modelBuilder.Entity("RealEstate.Infrastructure.Persistance.Entities.PropertyImage", b =>
                {
                    b.HasOne("RealEstate.Infrastructure.Persistance.Entities.Property", null)
                        .WithOne("MainImage")
                        .HasForeignKey("RealEstate.Infrastructure.Persistance.Entities.PropertyImage", "PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RealEstate.Infrastructure.Persistance.Entities.Property", "Property")
                        .WithMany("Images")
                        .HasForeignKey("PropertyId1");

                    b.Navigation("Property");
                });

            modelBuilder.Entity("RealEstate.Infrastructure.Persistance.Entities.Property", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("MainImage");
                });
#pragma warning restore 612, 618
        }
    }
}
