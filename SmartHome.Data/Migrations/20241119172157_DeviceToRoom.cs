using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartHome.Data.Migrations
{
    /// <inheritdoc />
    public partial class DeviceToRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("634a2607-8d2f-41c1-8bf3-f33d8567debc"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("df0bfb87-7c43-4f97-b4fa-4785d83f7c0c"));

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DevicesRooms",
                columns: table => new
                {
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeviceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevicesRooms", x => new { x.DeviceId, x.RoomId });
                    table.ForeignKey(
                        name: "FK_DevicesRooms_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DevicesRooms_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_DevicesRooms_RoomId",
                table: "DevicesRooms",
                column: "RoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DevicesRooms");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("2ab5c562-085c-48b0-9434-771fe691f542"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("709c7177-e012-4637-9dcf-7a54e29f8338"));

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "DeviceName", "Type" },
                values: new object[,]
                {
                    { new Guid("634a2607-8d2f-41c1-8bf3-f33d8567debc"), "Switch 2", 1 },
                    { new Guid("df0bfb87-7c43-4f97-b4fa-4785d83f7c0c"), "Switch 1", 1 }
                });
        }
    }
}
