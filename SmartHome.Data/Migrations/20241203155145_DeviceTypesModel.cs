using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartHome.Data.Migrations
{
    /// <inheritdoc />
    public partial class DeviceTypesModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("1afaa390-68c4-4369-9940-175ac830a55a"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("d39e0e67-131a-4d3a-ae19-9e7fbec5f8b5"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("388eab53-cf36-4ca3-8f86-8434327d13d9"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("54dcf9dc-2592-4c70-b356-aca4fb21f0cc"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("a34f878b-db20-45f8-a5a9-7ce9c773a87d"));

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "DeviceName", "Type" },
                values: new object[,]
                {
                    { new Guid("366938c6-b0c3-469d-9e88-5bdb0b70ab0f"), "Switch 2", 1 },
                    { new Guid("546d7c4d-3995-4507-a0a1-e662a4963a74"), "Switch 1", 1 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "RoomName" },
                values: new object[,]
                {
                    { new Guid("2cdf3eb1-0cdd-4cb6-bd0e-8358f368a4f6"), "Kitchen" },
                    { new Guid("4b148679-4fe5-4e52-9a8b-4edf5d9cd8c7"), "Bathroom" },
                    { new Guid("63166f82-3173-494b-b616-69dfe80a7189"), "Living Room" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("366938c6-b0c3-469d-9e88-5bdb0b70ab0f"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("546d7c4d-3995-4507-a0a1-e662a4963a74"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("2cdf3eb1-0cdd-4cb6-bd0e-8358f368a4f6"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("4b148679-4fe5-4e52-9a8b-4edf5d9cd8c7"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("63166f82-3173-494b-b616-69dfe80a7189"));

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "DeviceName", "Type" },
                values: new object[,]
                {
                    { new Guid("1afaa390-68c4-4369-9940-175ac830a55a"), "Switch 2", 1 },
                    { new Guid("d39e0e67-131a-4d3a-ae19-9e7fbec5f8b5"), "Switch 1", 1 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "RoomName" },
                values: new object[,]
                {
                    { new Guid("388eab53-cf36-4ca3-8f86-8434327d13d9"), "Bathroom" },
                    { new Guid("54dcf9dc-2592-4c70-b356-aca4fb21f0cc"), "Living Room" },
                    { new Guid("a34f878b-db20-45f8-a5a9-7ce9c773a87d"), "Kitchen" }
                });
        }
    }
}
