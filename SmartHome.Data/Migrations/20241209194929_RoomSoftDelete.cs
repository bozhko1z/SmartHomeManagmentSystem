using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartHome.Data.Migrations
{
    /// <inheritdoc />
    public partial class RoomSoftDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DevicesRooms_Rooms_RoomId",
                table: "DevicesRooms");

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("82a0d45a-c97d-4704-b5f4-5d4df7cce48d"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("ed4cab8e-7759-477d-b259-ceb91fd218f8"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("562d68da-6a64-45f2-a6b5-692a690e48a5"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("896bb656-d709-4730-ab31-30ba170397a2"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("c3e754eb-a95e-4a91-aecd-ed734d9b646c"));

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
                    { new Guid("a9db3d9b-c0ce-4526-9b3e-899919ba2db3"), "Switch 2", "Switch" },
                    { new Guid("f8f33058-bf79-4237-9e89-a49944a66c9d"), "Switch 1", "Switch" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "IsDeleted", "RoomName" },
                values: new object[,]
                {
                    { new Guid("37ab853f-3a80-49a9-b3b5-2774fb14e6a4"), false, "Kitchen" },
                    { new Guid("3acb494c-dac8-4461-a255-32a66e0963aa"), false, "Bathroom" },
                    { new Guid("d3392e9b-a016-4ab7-abae-85f5b56d40db"), false, "Living Room" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_DevicesRooms_Rooms_RoomId",
                table: "DevicesRooms",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DevicesRooms_Rooms_RoomId",
                table: "DevicesRooms");

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("a9db3d9b-c0ce-4526-9b3e-899919ba2db3"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("f8f33058-bf79-4237-9e89-a49944a66c9d"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("37ab853f-3a80-49a9-b3b5-2774fb14e6a4"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("3acb494c-dac8-4461-a255-32a66e0963aa"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("d3392e9b-a016-4ab7-abae-85f5b56d40db"));

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Rooms");

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "DeviceName", "Type" },
                values: new object[,]
                {
                    { new Guid("82a0d45a-c97d-4704-b5f4-5d4df7cce48d"), "Switch 1", "Switch" },
                    { new Guid("ed4cab8e-7759-477d-b259-ceb91fd218f8"), "Switch 2", "Switch" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "RoomName" },
                values: new object[,]
                {
                    { new Guid("562d68da-6a64-45f2-a6b5-692a690e48a5"), "Kitchen" },
                    { new Guid("896bb656-d709-4730-ab31-30ba170397a2"), "Living Room" },
                    { new Guid("c3e754eb-a95e-4a91-aecd-ed734d9b646c"), "Bathroom" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_DevicesRooms_Rooms_RoomId",
                table: "DevicesRooms",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
