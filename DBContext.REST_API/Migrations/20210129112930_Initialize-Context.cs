using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DBContext.REST_API.Migrations
{
    public partial class InitializeContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormFactor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormFactor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LookupSource",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupSource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcessorType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessorType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductMaster",
                columns: table => new
                {
                    ProductMasterId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ComputerTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProcessorId = table.Column<int>(type: "INTEGER", nullable: false),
                    BrandId = table.Column<int>(type: "INTEGER", nullable: false),
                    USBPorts = table.Column<int>(type: "INTEGER", nullable: false),
                    RamSlots = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Timestamp = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMaster", x => x.ProductMasterId);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductMasterId = table.Column<int>(type: "INTEGER", nullable: false),
                    PropertyName = table.Column<string>(type: "TEXT", nullable: false),
                    PropertyValue = table.Column<string>(type: "TEXT", nullable: false),
                    PropertyTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    LookUpSourceId = table.Column<int>(type: "INTEGER", nullable: true),
                    Timestamp = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDetails_ProductMaster_ProductMasterId",
                        column: x => x.ProductMasterId,
                        principalTable: "ProductMaster",
                        principalColumn: "ProductMasterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "HP" });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Dell" });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Lenovo" });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Microsoft" });

            migrationBuilder.InsertData(
                table: "FormFactor",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "MidTower" });

            migrationBuilder.InsertData(
                table: "FormFactor",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Tower" });

            migrationBuilder.InsertData(
                table: "LookupSource",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Brand" });

            migrationBuilder.InsertData(
                table: "LookupSource",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "FormFactor" });

            migrationBuilder.InsertData(
                table: "LookupSource",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "ProcessorType" });

            migrationBuilder.InsertData(
                table: "LookupSource",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "ProductType" });

            migrationBuilder.InsertData(
                table: "ProcessorType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "i9" });

            migrationBuilder.InsertData(
                table: "ProcessorType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "i7" });

            migrationBuilder.InsertData(
                table: "ProcessorType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "i3" });

            migrationBuilder.InsertData(
                table: "ProcessorType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "i5" });

            migrationBuilder.InsertData(
                table: "ProductMaster",
                columns: new[] { "ProductMasterId", "BrandId", "ComputerTypeId", "Description", "ProcessorId", "Quantity", "RamSlots", "USBPorts" },
                values: new object[] { 1, 2, 1, "Added the Desktop product through Seeding", 1, 100, 4, 3 });

            migrationBuilder.InsertData(
                table: "ProductMaster",
                columns: new[] { "ProductMasterId", "BrandId", "ComputerTypeId", "Description", "ProcessorId", "Quantity", "RamSlots", "USBPorts" },
                values: new object[] { 2, 1, 2, "Added the Laptop product through Seeding", 2, 50, 2, 3 });

            migrationBuilder.InsertData(
                table: "ProductType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Desktop" });

            migrationBuilder.InsertData(
                table: "ProductType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Laptop" });

            migrationBuilder.InsertData(
                table: "PropertyType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Int" });

            migrationBuilder.InsertData(
                table: "PropertyType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Long" });

            migrationBuilder.InsertData(
                table: "PropertyType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Text" });

            migrationBuilder.InsertData(
                table: "PropertyType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Dropdown" });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "Id", "LookUpSourceId", "ProductMasterId", "PropertyName", "PropertyTypeId", "PropertyValue" },
                values: new object[] { 1, 2, 1, "FormFactor", 4, "1" });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "Id", "LookUpSourceId", "ProductMasterId", "PropertyName", "PropertyTypeId", "PropertyValue" },
                values: new object[] { 2, null, 2, "Size", 1, "15" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_ProductMasterId",
                table: "ProductDetails",
                column: "ProductMasterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "FormFactor");

            migrationBuilder.DropTable(
                name: "LookupSource");

            migrationBuilder.DropTable(
                name: "ProcessorType");

            migrationBuilder.DropTable(
                name: "ProductDetails");

            migrationBuilder.DropTable(
                name: "ProductType");

            migrationBuilder.DropTable(
                name: "PropertyType");

            migrationBuilder.DropTable(
                name: "ProductMaster");
        }
    }
}
