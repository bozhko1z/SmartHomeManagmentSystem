using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartHome.Data.Migrations
{
    /// <inheritdoc />
    public partial class TypeFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("622439e6-f7e0-445b-86c6-8dcff8c4564b"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("667606c8-e261-4e81-a850-9cf62f3cb458"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("5f624f5b-a9ea-450c-addd-c9b8854e9857"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("6b491a9a-98a4-4d4f-b234-6190910a28e6"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("f7714599-099d-47a2-b1b6-10d0cf2a88ea"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "DeviceName", "Type" },
                values: new object[,]
                {
                    { new Guid("622439e6-f7e0-445b-86c6-8dcff8c4564b"), "Switch 1", 1 },
                    { new Guid("667606c8-e261-4e81-a850-9cf62f3cb458"), "Switch 2", 1 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "RoomName" },
                values: new object[,]
                {
                    { new Guid("5f624f5b-a9ea-450c-addd-c9b8854e9857"), "Living Room" },
                    { new Guid("6b491a9a-98a4-4d4f-b234-6190910a28e6"), "Bathroom" },
                    { new Guid("f7714599-099d-47a2-b1b6-10d0cf2a88ea"), "Kitchen" }
                });
        }
    }
}
