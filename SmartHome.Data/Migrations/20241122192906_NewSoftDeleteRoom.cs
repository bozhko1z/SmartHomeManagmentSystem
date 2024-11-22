using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartHome.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewSoftDeleteRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("5df0c4c4-3094-4bad-bf5a-1c236362d0b8"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("6df1a4d1-22f7-4e2f-aefb-dbbcef3bd06a"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("0ec2d40e-c5f3-43fe-8337-77bd8a4c20cf"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("2b752091-78f9-4d51-a492-bef2929d85c5"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("9fdde257-8527-4496-b1e3-417b0873ee3a"));

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Rooms");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DevicesRooms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "DeviceName", "Type" },
                values: new object[,]
                {
                    { new Guid("a4f4ae0d-b4e4-4fb1-8a20-9d20fb986172"), "Switch 2", 1 },
                    { new Guid("f20bca37-5510-407a-bc86-8a956a496d02"), "Switch 1", 1 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "RoomName" },
                values: new object[,]
                {
                    { new Guid("339e738e-e783-4ff1-b75b-1ecf7f7c634a"), "Bathroom" },
                    { new Guid("6a5be361-7399-4f80-8df9-248d35c8c14e"), "Kitchen" },
                    { new Guid("c8805ffb-ff4a-4af4-8647-49c5b3abdf31"), "Living Room" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("a4f4ae0d-b4e4-4fb1-8a20-9d20fb986172"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("f20bca37-5510-407a-bc86-8a956a496d02"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("339e738e-e783-4ff1-b75b-1ecf7f7c634a"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("6a5be361-7399-4f80-8df9-248d35c8c14e"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("c8805ffb-ff4a-4af4-8647-49c5b3abdf31"));

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DevicesRooms");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Rooms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "DeviceName", "Type" },
                values: new object[,]
                {
                    { new Guid("5df0c4c4-3094-4bad-bf5a-1c236362d0b8"), "Switch 2", 1 },
                    { new Guid("6df1a4d1-22f7-4e2f-aefb-dbbcef3bd06a"), "Switch 1", 1 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "RoomName" },
                values: new object[,]
                {
                    { new Guid("0ec2d40e-c5f3-43fe-8337-77bd8a4c20cf"), "Bathroom" },
                    { new Guid("2b752091-78f9-4d51-a492-bef2929d85c5"), "Living Room" },
                    { new Guid("9fdde257-8527-4496-b1e3-417b0873ee3a"), "Kitchen" }
                });
        }
    }
}
