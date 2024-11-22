using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartHome.Data.Migrations
{
    /// <inheritdoc />
    public partial class SoftDeleteRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
