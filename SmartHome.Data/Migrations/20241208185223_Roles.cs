using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartHome.Data.Migrations
{
    /// <inheritdoc />
    public partial class Roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("012246d0-1735-4f72-a43f-843cff8e8f65"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("04dc3319-e4da-4b35-ad03-3c71670eaa34"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("61b25703-ec13-4da1-8893-7975e0dbd90e"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("6ac5409e-9c57-42c3-8518-11b73c5e85f0"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("b4415c00-72c7-4005-ade3-769864577444"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("012246d0-1735-4f72-a43f-843cff8e8f65"), "Switch 2", "Switch" },
                    { new Guid("04dc3319-e4da-4b35-ad03-3c71670eaa34"), "Switch 1", "Switch" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "RoomName" },
                values: new object[,]
                {
                    { new Guid("61b25703-ec13-4da1-8893-7975e0dbd90e"), "Kitchen" },
                    { new Guid("6ac5409e-9c57-42c3-8518-11b73c5e85f0"), "Living Room" },
                    { new Guid("b4415c00-72c7-4005-ade3-769864577444"), "Bathroom" }
                });
        }
    }
}
