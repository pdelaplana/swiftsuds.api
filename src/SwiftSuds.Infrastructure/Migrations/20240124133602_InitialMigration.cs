using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwiftSuds.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Businesses",
                columns: table => new
                {
                    BusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Description = table.Column<string>(type: "nvarchar(120)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessServices", x => x.BusinessServiceId);
                    table.ForeignKey(
                        name: "FK_BusinessServices_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "BusinessId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PieceCount = table.Column<int>(type: "int", nullable: false),
                    ScheduledPickupDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualPickupDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PickupDriverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScheduledDeliveryDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualDeliveryDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDriverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_BusinessServices_BusinessServiceId",
                        column: x => x.BusinessServiceId,
                        principalTable: "BusinessServices",
                        principalColumn: "BusinessServiceId",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateIndex(
                name: "IX_BusinessEmployees_BusinessId",
                table: "BusinessEmployees",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessServices_BusinessId",
                table: "BusinessServices",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BusinessId",
                table: "Orders",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BusinessServiceId",
                table: "Orders",
                column: "BusinessServiceId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessEmployees");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "UserAccounts");

            migrationBuilder.DropTable(
                name: "BusinessServices");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Businesses");
        }
    }
}
