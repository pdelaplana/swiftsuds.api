using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SwiftSuds.Infrastructure.Persistence.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessOwners",
                columns: table => new
                {
                    BusinessOwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", nullable: false),
                    Address_City = table.Column<string>(type: "nvarchar(60)", nullable: true),
                    Address_PostCode = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Address_StreetAddress1 = table.Column<string>(type: "nvarchar(120)", nullable: false),
                    Address_StreetAddress2 = table.Column<string>(type: "nvarchar(120)", nullable: true),
                    Address_StreetAddress3 = table.Column<string>(type: "nvarchar(120)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(60)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessOwners", x => x.BusinessOwnerId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", nullable: false),
                    Address_City = table.Column<string>(type: "nvarchar(60)", nullable: true),
                    Address_PostCode = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Address_StreetAddress1 = table.Column<string>(type: "nvarchar(120)", nullable: false),
                    Address_StreetAddress2 = table.Column<string>(type: "nvarchar(120)", nullable: true),
                    Address_StreetAddress3 = table.Column<string>(type: "nvarchar(120)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(60)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    DriverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Vehicle_RegistrationExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Vehicle_RegistrationNumber = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Vehicle_VehicleType_Type = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    DriversLicense = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", nullable: false),
                    Address_City = table.Column<string>(type: "nvarchar(60)", nullable: true),
                    Address_PostCode = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Address_StreetAddress1 = table.Column<string>(type: "nvarchar(120)", nullable: false),
                    Address_StreetAddress2 = table.Column<string>(type: "nvarchar(120)", nullable: true),
                    Address_StreetAddress3 = table.Column<string>(type: "nvarchar(120)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(60)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.DriverId);
                });

            migrationBuilder.CreateTable(
                name: "UserAccounts",
                columns: table => new
                {
                    UserAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(60)", nullable: false),
                    AccountType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccounts", x => x.UserAccountId);
                });

            migrationBuilder.CreateTable(
                name: "Businesses",
                columns: table => new
                {
                    BusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessOwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Address_City = table.Column<string>(type: "nvarchar(60)", nullable: true),
                    Address_PostCode = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Address_StreetAddress1 = table.Column<string>(type: "nvarchar(120)", nullable: false),
                    Address_StreetAddress2 = table.Column<string>(type: "nvarchar(120)", nullable: true),
                    Address_StreetAddress3 = table.Column<string>(type: "nvarchar(120)", nullable: true),
                    ServiceRadius = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Businesses", x => x.BusinessId);
                    table.ForeignKey(
                        name: "FK_Businesses_BusinessOwners_BusinessOwnerId",
                        column: x => x.BusinessOwnerId,
                        principalTable: "BusinessOwners",
                        principalColumn: "BusinessOwnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessEmployees",
                columns: table => new
                {
                    BusinessEmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", nullable: false),
                    Address_City = table.Column<string>(type: "nvarchar(60)", nullable: true),
                    Address_PostCode = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Address_StreetAddress1 = table.Column<string>(type: "nvarchar(120)", nullable: false),
                    Address_StreetAddress2 = table.Column<string>(type: "nvarchar(120)", nullable: true),
                    Address_StreetAddress3 = table.Column<string>(type: "nvarchar(120)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(60)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessEmployees", x => x.BusinessEmployeeId);
                    table.ForeignKey(
                        name: "FK_BusinessEmployees_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "BusinessId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusinessServices",
                columns: table => new
                {
                    BusinessServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(120)", nullable: true),
                    Price_Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Price_Currency_Symbol = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    MaxQuantityPerOrder = table.Column<int>(type: "int", nullable: false),
                    Sequence = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessServices", x => x.BusinessServiceId);
                    table.ForeignKey(
                        name: "FK_BusinessServices_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "BusinessId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PieceCount = table.Column<int>(type: "int", nullable: false),
                    PickupAddress_City = table.Column<string>(type: "nvarchar(60)", nullable: true),
                    PickupAddress_PostCode = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    PickupAddress_StreetAddress1 = table.Column<string>(type: "nvarchar(120)", nullable: false),
                    PickupAddress_StreetAddress2 = table.Column<string>(type: "nvarchar(120)", nullable: true),
                    PickupAddress_StreetAddress3 = table.Column<string>(type: "nvarchar(120)", nullable: true),
                    ScheduledPickupDateTimeStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ScheduledPickupDateTimeEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualPickupDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PickupDriverId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeliveryAddress_City = table.Column<string>(type: "nvarchar(60)", nullable: true),
                    DeliveryAddress_PostCode = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    DeliveryAddress_StreetAddress1 = table.Column<string>(type: "nvarchar(120)", nullable: false),
                    DeliveryAddress_StreetAddress2 = table.Column<string>(type: "nvarchar(120)", nullable: true),
                    DeliveryAddress_StreetAddress3 = table.Column<string>(type: "nvarchar(120)", nullable: true),
                    ScheduledDeliveryDateTimeStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ScheduledDeliveryDateTimeEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualDeliveryDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDriverId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    AmountDue_Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    AmountDue_Currency_Symbol = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    AmountPaid_Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    AmountPaid_Currency_Symbol = table.Column<string>(type: "nvarchar(5)", nullable: true),
                    IsCancelled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "BusinessId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Drivers_DeliveryDriverId",
                        column: x => x.DeliveryDriverId,
                        principalTable: "Drivers",
                        principalColumn: "DriverId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Drivers_PickupDriverId",
                        column: x => x.PickupDriverId,
                        principalTable: "Drivers",
                        principalColumn: "DriverId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    OrderItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Item = table.Column<string>(type: "nvarchar(60)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItem_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderService",
                columns: table => new
                {
                    OrderServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FinalPrice_Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    FinalPrice_Currency_Symbol = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderService", x => x.OrderServiceId);
                    table.ForeignKey(
                        name: "FK_OrderService_BusinessServices_BusinessServiceId",
                        column: x => x.BusinessServiceId,
                        principalTable: "BusinessServices",
                        principalColumn: "BusinessServiceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderService_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "BusinessOwners",
                columns: new[] { "BusinessOwnerId", "Email", "Name", "Phone", "Address_City", "Address_PostCode", "Address_StreetAddress1", "Address_StreetAddress2", "Address_StreetAddress3" },
                values: new object[] { new Guid("792b370a-ca62-4ab5-a075-e053117fe8f1"), "business.owner@mail.com", "Business Owner", "+619019090", null, null, "1 Main Street", null, null });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Email", "Name", "Phone", "Address_City", "Address_PostCode", "Address_StreetAddress1", "Address_StreetAddress2", "Address_StreetAddress3" },
                values: new object[] { new Guid("a8307ac9-ecb2-4044-a665-37dc743ed839"), "seed.customer@mail.com", "Seed Customer", "+619617891787", null, null, "1 Main Street", null, null });

            migrationBuilder.InsertData(
                table: "UserAccounts",
                columns: new[] { "UserAccountId", "AccountType", "Email" },
                values: new object[,]
                {
                    { new Guid("5cb466e8-938d-444f-a133-134557e18a34"), 2, "business.owner@mail.com" },
                    { new Guid("db85f1e2-0ec2-46e7-a3e4-e22caece3566"), 0, "seed.customer@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Businesses",
                columns: new[] { "BusinessId", "BusinessOwnerId", "Name", "ServiceRadius", "Address_City", "Address_PostCode", "Address_StreetAddress1", "Address_StreetAddress2", "Address_StreetAddress3" },
                values: new object[] { new Guid("c7e0c728-a2b7-4dab-85ea-a5835ddd149f"), new Guid("792b370a-ca62-4ab5-a075-e053117fe8f1"), "SwiftSuds Laundry", 10.0, null, null, "1 Main Street", null, null });

            migrationBuilder.InsertData(
                table: "BusinessServices",
                columns: new[] { "BusinessServiceId", "BusinessId", "Description", "MaxQuantityPerOrder", "Name", "Sequence", "Price_Amount", "Price_Currency_Symbol" },
                values: new object[,]
                {
                    { new Guid("340a07c5-7bd5-401a-b34f-59ce9ede4fa0"), new Guid("c7e0c728-a2b7-4dab-85ea-a5835ddd149f"), null, 1, "Ironing", 5, 50m, "PHP" },
                    { new Guid("b20a8e3b-6557-49e4-a49b-6a80e7582597"), new Guid("c7e0c728-a2b7-4dab-85ea-a5835ddd149f"), null, 5, "Folds (Max 8 Kilos)", 3, 50m, "PHP" },
                    { new Guid("c2828b67-6107-4fde-8df5-d12eb3de7f32"), new Guid("c7e0c728-a2b7-4dab-85ea-a5835ddd149f"), null, 1, "Dry Cleaning", 4, 50m, "PHP" },
                    { new Guid("c58a7a3c-1c43-43a8-b425-dff82c915792"), new Guid("c7e0c728-a2b7-4dab-85ea-a5835ddd149f"), null, 5, "Wash (Max 8 Kilos)", 1, 75m, "PHP" },
                    { new Guid("ef63e303-7fcf-4758-9835-862ef7d98503"), new Guid("c7e0c728-a2b7-4dab-85ea-a5835ddd149f"), null, 5, "Dry (Max 8 Kilos)", 2, 75m, "PHP" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessEmployees_BusinessId",
                table: "BusinessEmployees",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_BusinessOwnerId",
                table: "Businesses",
                column: "BusinessOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessServices_BusinessId",
                table: "BusinessServices",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BusinessId",
                table: "Orders",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryDriverId",
                table: "Orders",
                column: "DeliveryDriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PickupDriverId",
                table: "Orders",
                column: "PickupDriverId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderService_BusinessServiceId",
                table: "OrderService",
                column: "BusinessServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderService_OrderId",
                table: "OrderService",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessEmployees");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "OrderService");

            migrationBuilder.DropTable(
                name: "UserAccounts");

            migrationBuilder.DropTable(
                name: "BusinessServices");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Businesses");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "BusinessOwners");
        }
    }
}
