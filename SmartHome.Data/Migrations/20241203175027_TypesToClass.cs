using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartHome.Data.Migrations
{
    /// <inheritdoc />
    public partial class TypesToClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Devices",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Devices",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
    }
}
