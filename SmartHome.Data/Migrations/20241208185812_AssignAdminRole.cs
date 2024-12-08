using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartHome.Data.Migrations
{
    /// <inheritdoc />
    public partial class AssignAdminRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("18a1522c-ad7a-4c17-ad3c-94ae4da4f61b"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("ffb6352f-4901-416e-8690-f3ade111ff9d"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("a05d1006-2cb3-4c84-b219-c7f8bec55dfb"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("a3a27f4b-81fa-4202-a037-c8faa20025a5"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("fe2d1abf-f5d6-40d3-8a86-4adf4e215274"));

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "DeviceName", "Type" },
                values: new object[,]
                {
                    { new Guid("82a0d45a-c97d-4704-b5f4-5d4df7cce48d"), "Switch 1", "Switch" },
                    { new Guid("ed4cab8e-7759-477d-b259-ceb91fd218f8"), "Switch 2", "Switch" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "RoomName" },
                values: new object[,]
                {
                    { new Guid("562d68da-6a64-45f2-a6b5-692a690e48a5"), "Kitchen" },
                    { new Guid("896bb656-d709-4730-ab31-30ba170397a2"), "Living Room" },
                    { new Guid("c3e754eb-a95e-4a91-aecd-ed734d9b646c"), "Bathroom" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("82a0d45a-c97d-4704-b5f4-5d4df7cce48d"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("ed4cab8e-7759-477d-b259-ceb91fd218f8"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("562d68da-6a64-45f2-a6b5-692a690e48a5"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("896bb656-d709-4730-ab31-30ba170397a2"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("c3e754eb-a95e-4a91-aecd-ed734d9b646c"));

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "DeviceName", "Type" },
                values: new object[,]
                {
                    { new Guid("18a1522c-ad7a-4c17-ad3c-94ae4da4f61b"), "Switch 1", "Switch" },
                    { new Guid("ffb6352f-4901-416e-8690-f3ade111ff9d"), "Switch 2", "Switch" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "RoomName" },
                values: new object[,]
                {
                    { new Guid("a05d1006-2cb3-4c84-b219-c7f8bec55dfb"), "Bathroom" },
                    { new Guid("a3a27f4b-81fa-4202-a037-c8faa20025a5"), "Kitchen" },
                    { new Guid("fe2d1abf-f5d6-40d3-8a86-4adf4e215274"), "Living Room" }
                });
        }
    }
}
