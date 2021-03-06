﻿// <auto-generated />
using System;
using DBContext.REST_API;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DBContext.REST_API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Common.REST_API.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Brand");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "HP"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Dell"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Lenovo"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Microsoft"
                        });
                });

            modelBuilder.Entity("Common.REST_API.FormFactor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("FormFactor");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "MidTower"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Tower"
                        });
                });

            modelBuilder.Entity("Common.REST_API.LookupSource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("LookupSource");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Brand"
                        },
                        new
                        {
                            Id = 2,
                            Name = "FormFactor"
                        },
                        new
                        {
                            Id = 3,
                            Name = "ProcessorType"
                        },
                        new
                        {
                            Id = 4,
                            Name = "ProductType"
                        });
                });

            modelBuilder.Entity("Common.REST_API.ProcessorType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ProcessorType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "i3"
                        },
                        new
                        {
                            Id = 2,
                            Name = "i5"
                        },
                        new
                        {
                            Id = 3,
                            Name = "i7"
                        },
                        new
                        {
                            Id = 4,
                            Name = "i9"
                        });
                });

            modelBuilder.Entity("Common.REST_API.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ProductType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Desktop"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Laptop"
                        });
                });

            modelBuilder.Entity("Common.REST_API.PropertyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PropertyType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Int"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Long"
                        },
                        new
                        {
                            Id = 3,
                            Name = "String"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Dropdown"
                        });
                });

            modelBuilder.Entity("Entities.REST_API.ProductDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("LookUpSourceId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductMasterId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PropertyName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PropertyTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PropertyValue")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.HasKey("Id");

                    b.HasIndex("ProductMasterId");

                    b.ToTable("ProductDetails");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProductMasterId = 1,
                            PropertyName = "FormFactor",
                            PropertyTypeId = 3,
                            PropertyValue = "MidTower"
                        },
                        new
                        {
                            Id = 2,
                            ProductMasterId = 2,
                            PropertyName = "Size",
                            PropertyTypeId = 3,
                            PropertyValue = "15"
                        });
                });

            modelBuilder.Entity("Entities.REST_API.ProductMaster", b =>
                {
                    b.Property<int>("ProductMasterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BrandId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ComputerTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProcessorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RamSlots")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.Property<int>("USBPorts")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProductMasterId");

                    b.ToTable("ProductMaster");

                    b.HasData(
                        new
                        {
                            ProductMasterId = 1,
                            BrandId = 2,
                            ComputerTypeId = 1,
                            Description = "Added the Desktop product through Seeding",
                            ProcessorId = 1,
                            Quantity = 100,
                            RamSlots = 4,
                            USBPorts = 3
                        },
                        new
                        {
                            ProductMasterId = 2,
                            BrandId = 1,
                            ComputerTypeId = 2,
                            Description = "Added the Laptop product through Seeding",
                            ProcessorId = 2,
                            Quantity = 50,
                            RamSlots = 2,
                            USBPorts = 3
                        });
                });

            modelBuilder.Entity("Entities.REST_API.ProductDetail", b =>
                {
                    b.HasOne("Entities.REST_API.ProductMaster", "ProductMaster")
                        .WithMany("ProductDetails")
                        .HasForeignKey("ProductMasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductMaster");
                });

            modelBuilder.Entity("Entities.REST_API.ProductMaster", b =>
                {
                    b.Navigation("ProductDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
