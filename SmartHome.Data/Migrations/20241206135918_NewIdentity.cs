using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartHome.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("32f0a7a9-7181-4843-a1d6-3f0981403b9f"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("b7e890c0-f15d-45d0-8684-b440a7dbf186"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("1ba2e4b8-7a76-4ebf-b9ea-0dafbd06c8ec"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("b159f552-7db8-4638-b38b-b37754f52215"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("d205237e-0820-45ce-acdf-8215c91d95bb"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("32f0a7a9-7181-4843-a1d6-3f0981403b9f"), "Switch 1", "Switch" },
                    { new Guid("b7e890c0-f15d-45d0-8684-b440a7dbf186"), "Switch 2", "Switch" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "RoomName" },
                values: new object[,]
                {
                    { new Guid("1ba2e4b8-7a76-4ebf-b9ea-0dafbd06c8ec"), "Kitchen" },
                    { new Guid("b159f552-7db8-4638-b38b-b37754f52215"), "Living Room" },
                    { new Guid("d205237e-0820-45ce-acdf-8215c91d95bb"), "Bathroom" }
                });
        }
    }
}
