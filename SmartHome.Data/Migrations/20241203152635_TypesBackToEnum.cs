using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartHome.Data.Migrations
{
    /// <inheritdoc />
    public partial class TypesBackToEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("0b8bc1af-7527-4623-8088-a476b45eab02"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("dfd98b5f-9afb-4087-a50c-b03799e0b344"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("61a645da-db27-45cb-a0f9-2769853c4972"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("d7b7f9ff-c503-4182-b6bc-89426e654066"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("fd72719d-3c0c-49f0-9f14-a46d484d23f7"));

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Devices",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DeviceName",
                table: "Devices",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Devices",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "DeviceName",
                table: "Devices",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "DeviceName", "Type" },
                values: new object[,]
                {
                    { new Guid("0b8bc1af-7527-4623-8088-a476b45eab02"), "Switch 1", "Light" },
                    { new Guid("dfd98b5f-9afb-4087-a50c-b03799e0b344"), "Switch 2", "Light" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "RoomName" },
                values: new object[,]
                {
                    { new Guid("61a645da-db27-45cb-a0f9-2769853c4972"), "Living Room" },
                    { new Guid("d7b7f9ff-c503-4182-b6bc-89426e654066"), "Kitchen" },
                    { new Guid("fd72719d-3c0c-49f0-9f14-a46d484d23f7"), "Bathroom" }
                });
        }
    }
}
