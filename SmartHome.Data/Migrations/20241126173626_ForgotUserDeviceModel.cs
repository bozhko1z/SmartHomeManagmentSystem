using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartHome.Data.Migrations
{
    /// <inheritdoc />
    public partial class ForgotUserDeviceModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDevice_AspNetUsers_UserId",
                table: "UserDevice");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDevice_Devices_DeviceId",
                table: "UserDevice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDevice",
                table: "UserDevice");

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("03845adf-21b9-4904-a8ea-dc9f835ddc14"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("b05a4d22-6ce5-4199-8d0c-074fa4f494b0"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("0e099bd5-8af6-4b9f-99b9-6ba76108ceff"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("6f494a33-c1c0-477e-b92e-bfb765dea812"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("d7681b6e-ce62-4ff1-bd58-53d965f0b52b"));

            migrationBuilder.RenameTable(
                name: "UserDevice",
                newName: "UsersDevices");

            migrationBuilder.RenameIndex(
                name: "IX_UserDevice_DeviceId",
                table: "UsersDevices",
                newName: "IX_UsersDevices_DeviceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersDevices",
                table: "UsersDevices",
                columns: new[] { "UserId", "DeviceId" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_UsersDevices_AspNetUsers_UserId",
                table: "UsersDevices",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersDevices_Devices_DeviceId",
                table: "UsersDevices",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersDevices_AspNetUsers_UserId",
                table: "UsersDevices");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersDevices_Devices_DeviceId",
                table: "UsersDevices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersDevices",
                table: "UsersDevices");

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

            migrationBuilder.RenameTable(
                name: "UsersDevices",
                newName: "UserDevice");

            migrationBuilder.RenameIndex(
                name: "IX_UsersDevices_DeviceId",
                table: "UserDevice",
                newName: "IX_UserDevice_DeviceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDevice",
                table: "UserDevice",
                columns: new[] { "UserId", "DeviceId" });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "DeviceName", "Type" },
                values: new object[,]
                {
                    { new Guid("03845adf-21b9-4904-a8ea-dc9f835ddc14"), "Switch 1", 1 },
                    { new Guid("b05a4d22-6ce5-4199-8d0c-074fa4f494b0"), "Switch 2", 1 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "RoomName" },
                values: new object[,]
                {
                    { new Guid("0e099bd5-8af6-4b9f-99b9-6ba76108ceff"), "Kitchen" },
                    { new Guid("6f494a33-c1c0-477e-b92e-bfb765dea812"), "Living Room" },
                    { new Guid("d7681b6e-ce62-4ff1-bd58-53d965f0b52b"), "Bathroom" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UserDevice_AspNetUsers_UserId",
                table: "UserDevice",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDevice_Devices_DeviceId",
                table: "UserDevice",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
