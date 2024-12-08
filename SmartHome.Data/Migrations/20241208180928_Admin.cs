using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartHome.Data.Migrations
{
    /// <inheritdoc />
    public partial class Admin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("370e9ca8-3a1f-4bad-854a-7225af8d79c7"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("f42d8d61-141d-447f-8ba7-94217a957db7"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("095c3f87-b178-42c9-b3ca-8a53cc2a8ec5"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("1c05bc75-035c-4035-a6a3-5a235b226da4"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("b84f7766-1b94-4d24-a81b-18a5807cbdac"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("370e9ca8-3a1f-4bad-854a-7225af8d79c7"), "Switch 2", "Switch" },
                    { new Guid("f42d8d61-141d-447f-8ba7-94217a957db7"), "Switch 1", "Switch" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "RoomName" },
                values: new object[,]
                {
                    { new Guid("095c3f87-b178-42c9-b3ca-8a53cc2a8ec5"), "Bathroom" },
                    { new Guid("1c05bc75-035c-4035-a6a3-5a235b226da4"), "Kitchen" },
                    { new Guid("b84f7766-1b94-4d24-a81b-18a5807cbdac"), "Living Room" }
                });
        }
    }
}
