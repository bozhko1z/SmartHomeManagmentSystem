using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartHome.Data.Migrations
{
    /// <inheritdoc />
    public partial class TryingToFixAddDevice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "DeviceName", "IsDeleted", "Type" },
                values: new object[,]
                {
                    { new Guid("7b78563f-da17-44db-b544-6528978b9371"), "Switch 2", false, "Switch" },
                    { new Guid("8a67048d-89cc-46b3-81e9-fed166a877ea"), "Switch 1", false, "Switch" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "IsDeleted", "RoomName" },
                values: new object[,]
                {
                    { new Guid("41a20d44-a46a-4929-afdb-21290d9f25cf"), false, "Kitchen" },
                    { new Guid("43947bb7-f4da-4cb7-b964-e5b3dd321547"), false, "Living Room" },
                    { new Guid("ab71352e-24a4-4744-9576-03023d61adec"), false, "Bathroom" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("7b78563f-da17-44db-b544-6528978b9371"));

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: new Guid("8a67048d-89cc-46b3-81e9-fed166a877ea"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("41a20d44-a46a-4929-afdb-21290d9f25cf"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("43947bb7-f4da-4cb7-b964-e5b3dd321547"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("ab71352e-24a4-4744-9576-03023d61adec"));

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
        }
    }
}
