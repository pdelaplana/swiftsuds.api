﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SwiftSuds.Infrastructure.Persistence.EFCore.Contexts;

#nullable disable

namespace SwiftSuds.Infrastructure.Persistence.EfCore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SwiftSuds.Domain.Entities.BusinessEmployees.BusinessEmployee", b =>
                {
                    b.Property<Guid>("BusinessEmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BusinessId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("BusinessEmployeeId");

                    b.HasIndex("BusinessId");

                    b.ToTable("BusinessEmployees");
                });

            modelBuilder.Entity("SwiftSuds.Domain.Entities.BusinessServices.BusinessService", b =>
                {
                    b.Property<Guid>("BusinessServiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BusinessId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("BusinessServiceId");

                    b.HasIndex("BusinessId");

                    b.ToTable("BusinessServices");
                });

            modelBuilder.Entity("SwiftSuds.Domain.Entities.Businesses.Business", b =>
                {
                    b.Property<Guid>("BusinessId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("ServiceRadius")
                        .HasColumnType("float");

                    b.HasKey("BusinessId");

                    b.ToTable("Businesses");
                });

            modelBuilder.Entity("SwiftSuds.Domain.Entities.Customers.Customer", b =>
                {
                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("SwiftSuds.Domain.Entities.Drivers.Driver", b =>
                {
                    b.Property<Guid>("DriverId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DriversLicense")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("DriverId");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("SwiftSuds.Domain.Entities.Orders.Order", b =>
                {
                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ActualDeliveryDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ActualPickupDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("BusinessId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BusinessServiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DeliveryDriverId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PickupDriverId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PieceCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ScheduledDeliveryDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ScheduledPickupDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("OrderId");

                    b.HasIndex("BusinessId");

                    b.HasIndex("BusinessServiceId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DeliveryDriverId");

                    b.HasIndex("PickupDriverId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("SwiftSuds.Domain.Entities.BusinessEmployees.BusinessEmployee", b =>
                {
                    b.HasOne("SwiftSuds.Domain.Entities.Businesses.Business", "Business")
                        .WithMany("BusinessEmployees")
                        .HasForeignKey("BusinessId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.OwnsOne("SwiftSuds.Domain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("BusinessEmployeeId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("City")
                                .HasColumnType("nvarchar(60)");

                            b1.Property<string>("PostCode")
                                .HasColumnType("nvarchar(10)");

                            b1.Property<string>("StreetAddress1")
                                .IsRequired()
                                .HasColumnType("nvarchar(120)");

                            b1.Property<string>("StreetAddress2")
                                .HasColumnType("nvarchar(120)");

                            b1.Property<string>("StreetAddress3")
                                .HasColumnType("nvarchar(120)");

                            b1.HasKey("BusinessEmployeeId");

                            b1.ToTable("BusinessEmployees");

                            b1.WithOwner()
                                .HasForeignKey("BusinessEmployeeId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Business");
                });

            modelBuilder.Entity("SwiftSuds.Domain.Entities.BusinessServices.BusinessService", b =>
                {
                    b.HasOne("SwiftSuds.Domain.Entities.Businesses.Business", "Business")
                        .WithMany("BusinessServices")
                        .HasForeignKey("BusinessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("SwiftSuds.Domain.ValueObjects.Money", "Price", b1 =>
                        {
                            b1.Property<Guid>("BusinessServiceId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("BusinessServiceId");

                            b1.ToTable("BusinessServices");

                            b1.WithOwner()
                                .HasForeignKey("BusinessServiceId");
                        });

                    b.Navigation("Business");

                    b.Navigation("Price")
                        .IsRequired();
                });

            modelBuilder.Entity("SwiftSuds.Domain.Entities.Businesses.Business", b =>
                {
                    b.OwnsOne("SwiftSuds.Domain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("BusinessId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("City")
                                .HasColumnType("nvarchar(60)");

                            b1.Property<string>("PostCode")
                                .HasColumnType("nvarchar(10)");

                            b1.Property<string>("StreetAddress1")
                                .IsRequired()
                                .HasColumnType("nvarchar(120)");

                            b1.Property<string>("StreetAddress2")
                                .HasColumnType("nvarchar(120)");

                            b1.Property<string>("StreetAddress3")
                                .HasColumnType("nvarchar(120)");

                            b1.HasKey("BusinessId");

                            b1.ToTable("Businesses");

                            b1.WithOwner()
                                .HasForeignKey("BusinessId");
                        });

                    b.Navigation("Address")
                        .IsRequired();
                });

            modelBuilder.Entity("SwiftSuds.Domain.Entities.Customers.Customer", b =>
                {
                    b.OwnsOne("SwiftSuds.Domain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("City")
                                .HasColumnType("nvarchar(60)");

                            b1.Property<string>("PostCode")
                                .HasColumnType("nvarchar(10)");

                            b1.Property<string>("StreetAddress1")
                                .IsRequired()
                                .HasColumnType("nvarchar(120)");

                            b1.Property<string>("StreetAddress2")
                                .HasColumnType("nvarchar(120)");

                            b1.Property<string>("StreetAddress3")
                                .HasColumnType("nvarchar(120)");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.Navigation("Address")
                        .IsRequired();
                });

            modelBuilder.Entity("SwiftSuds.Domain.Entities.Drivers.Driver", b =>
                {
                    b.OwnsOne("SwiftSuds.Domain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("DriverId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("City")
                                .HasColumnType("nvarchar(60)");

                            b1.Property<string>("PostCode")
                                .HasColumnType("nvarchar(10)");

                            b1.Property<string>("StreetAddress1")
                                .IsRequired()
                                .HasColumnType("nvarchar(120)");

                            b1.Property<string>("StreetAddress2")
                                .HasColumnType("nvarchar(120)");

                            b1.Property<string>("StreetAddress3")
                                .HasColumnType("nvarchar(120)");

                            b1.HasKey("DriverId");

                            b1.ToTable("Drivers");

                            b1.WithOwner()
                                .HasForeignKey("DriverId");
                        });

                    b.OwnsOne("SwiftSuds.Domain.ValueObjects.Vehicle", "Vehicle", b1 =>
                        {
                            b1.Property<Guid>("DriverId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime?>("RegistrationExpiryDate")
                                .HasColumnType("datetime2");

                            b1.Property<string>("RegistrationNumber")
                                .IsRequired()
                                .HasColumnType("nvarchar(20)");

                            b1.HasKey("DriverId");

                            b1.ToTable("Drivers");

                            b1.WithOwner()
                                .HasForeignKey("DriverId");

                            b1.OwnsOne("SwiftSuds.Domain.ValueObjects.VehicleType", "VehicleType", b2 =>
                                {
                                    b2.Property<Guid>("VehicleDriverId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<string>("Type")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(20)");

                                    b2.HasKey("VehicleDriverId");

                                    b2.ToTable("Drivers");

                                    b2.WithOwner()
                                        .HasForeignKey("VehicleDriverId");
                                });

                            b1.Navigation("VehicleType");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Vehicle")
                        .IsRequired();
                });

            modelBuilder.Entity("SwiftSuds.Domain.Entities.Orders.Order", b =>
                {
                    b.HasOne("SwiftSuds.Domain.Entities.Businesses.Business", "Business")
                        .WithMany("Orders")
                        .HasForeignKey("BusinessId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SwiftSuds.Domain.Entities.BusinessServices.BusinessService", "BusinessService")
                        .WithMany("Orders")
                        .HasForeignKey("BusinessServiceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SwiftSuds.Domain.Entities.Customers.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SwiftSuds.Domain.Entities.Drivers.Driver", "DeliveryDriver")
                        .WithMany("DeliveryOrders")
                        .HasForeignKey("DeliveryDriverId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SwiftSuds.Domain.Entities.Drivers.Driver", "PickupDriver")
                        .WithMany("PickupOrders")
                        .HasForeignKey("PickupDriverId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.OwnsOne("SwiftSuds.Domain.ValueObjects.Money", "AmountDue", b1 =>
                        {
                            b1.Property<Guid>("OrderId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.Navigation("AmountDue")
                        .IsRequired();

                    b.Navigation("Business");

                    b.Navigation("BusinessService");

                    b.Navigation("Customer");

                    b.Navigation("DeliveryDriver");

                    b.Navigation("PickupDriver");
                });

            modelBuilder.Entity("SwiftSuds.Domain.Entities.BusinessServices.BusinessService", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("SwiftSuds.Domain.Entities.Businesses.Business", b =>
                {
                    b.Navigation("BusinessEmployees");

                    b.Navigation("BusinessServices");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("SwiftSuds.Domain.Entities.Customers.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("SwiftSuds.Domain.Entities.Drivers.Driver", b =>
                {
                    b.Navigation("DeliveryOrders");

                    b.Navigation("PickupOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
