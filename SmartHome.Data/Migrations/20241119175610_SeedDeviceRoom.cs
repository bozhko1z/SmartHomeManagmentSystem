using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartHome.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDeviceRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("2ab5c562-085c-48b0-9434-771fe691f542"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("709c7177-e012-4637-9dcf-7a54e29f8338"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("38af0499-bbfa-47b5-915c-5228d7a6458d"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("ccb422a0-e8f6-421b-8e53-307b51ff71ed"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("f207a024-bdf9-4304-b0fe-6b92c598a489"));

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "DeviceName", "Type" },
                values: new object[,]
                {
                    { new Guid("1292b51a-cf71-4af0-8b0f-c192074c5c71"), "Switch 1", 1 },
                    { new Guid("2cc4e79d-24d6-45a8-99fa-f98e5993368f"), "Switch 2", 1 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "RoomName" },
                values: new object[,]
                {
                    { new Guid("36688ddc-fddb-4f89-9f06-f6ce98e70156"), "Bathroom" },
                    { new Guid("77d03dde-b39b-4a88-a457-10705d62dd45"), "Living Room" },
                    { new Guid("d0155568-4a3c-4147-9eb5-a592baa1d7e3"), "Kitchen" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("1292b51a-cf71-4af0-8b0f-c192074c5c71"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("2cc4e79d-24d6-45a8-99fa-f98e5993368f"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("36688ddc-fddb-4f89-9f06-f6ce98e70156"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("77d03dde-b39b-4a88-a457-10705d62dd45"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("d0155568-4a3c-4147-9eb5-a592baa1d7e3"));

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "DeviceName", "Type" },
                values: new object[,]
                {
                    { new Guid("2ab5c562-085c-48b0-9434-771fe691f542"), "Switch 1", 1 },
                    { new Guid("709c7177-e012-4637-9dcf-7a54e29f8338"), "Switch 2", 1 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "RoomName" },
                values: new object[,]
                {
                    { new Guid("38af0499-bbfa-47b5-915c-5228d7a6458d"), "Bathroom" },
                    { new Guid("ccb422a0-e8f6-421b-8e53-307b51ff71ed"), "Living Room" },
                    { new Guid("f207a024-bdf9-4304-b0fe-6b92c598a489"), "Kitchen" }
                });
        }
    }
}
