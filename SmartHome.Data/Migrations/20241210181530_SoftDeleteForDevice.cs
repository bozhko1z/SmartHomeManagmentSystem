using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartHome.Data.Migrations
{
    /// <inheritdoc />
    public partial class SoftDeleteForDevice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DevicesRooms_Devices_DeviceId",
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

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Devices",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "DeviceName", "IsDeleted", "Type" },
                values: new object[,]
                {
                    { new Guid("054221e3-5b97-4cea-ba70-7f165e163538"), "Switch 2", false, "Switch" },
                    { new Guid("0e708cdf-6120-44d6-b3d2-2a51e0dc8bbe"), "Switch 1", false, "Switch" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "IsDeleted", "RoomName" },
                values: new object[,]
                {
                    { new Guid("26df5e58-4736-4496-a153-ed0ac9a1d690"), false, "Living Room" },
                    { new Guid("3e9d43c9-98ad-4c83-9f76-1582c1936922"), false, "Kitchen" },
                    { new Guid("f22f21e1-7e1c-4c96-9895-95d3a271caad"), false, "Bathroom" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_DevicesRooms_Devices_DeviceId",
                table: "DevicesRooms",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DevicesRooms_Devices_DeviceId",
                table: "DevicesRooms");

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("054221e3-5b97-4cea-ba70-7f165e163538"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("0e708cdf-6120-44d6-b3d2-2a51e0dc8bbe"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("26df5e58-4736-4496-a153-ed0ac9a1d690"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("3e9d43c9-98ad-4c83-9f76-1582c1936922"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("f22f21e1-7e1c-4c96-9895-95d3a271caad"));

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Devices");

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
                name: "FK_DevicesRooms_Devices_DeviceId",
                table: "DevicesRooms",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
