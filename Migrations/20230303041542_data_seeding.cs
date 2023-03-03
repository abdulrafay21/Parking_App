using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ParkingApp.Migrations
{
    /// <inheritdoc />
    public partial class dataseeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Parkings",
                columns: new[] { "ID", "city", "isBooked", "name", "price", "timer" },
                values: new object[,]
                {
                    { 10L, "lahore", false, "park1", 500, new DateTime(2023, 3, 3, 9, 15, 42, 253, DateTimeKind.Local).AddTicks(6101) },
                    { 11L, "lahore", false, "park2", 600, new DateTime(2023, 3, 3, 9, 15, 42, 253, DateTimeKind.Local).AddTicks(6116) },
                    { 12L, "karachi", false, "park1", 1000, new DateTime(2023, 3, 3, 9, 15, 42, 253, DateTimeKind.Local).AddTicks(6117) },
                    { 13L, "qasur", false, "park5", 200, new DateTime(2023, 3, 3, 9, 15, 42, 253, DateTimeKind.Local).AddTicks(6215) },
                    { 14L, "qasur", false, "park7", 900, new DateTime(2023, 3, 3, 9, 15, 42, 253, DateTimeKind.Local).AddTicks(6217) },
                    { 19L, "lahore", false, "park5", 900, new DateTime(2023, 3, 3, 9, 15, 42, 253, DateTimeKind.Local).AddTicks(6219) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parkings",
                keyColumn: "ID",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Parkings",
                keyColumn: "ID",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Parkings",
                keyColumn: "ID",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Parkings",
                keyColumn: "ID",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Parkings",
                keyColumn: "ID",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Parkings",
                keyColumn: "ID",
                keyValue: 19L);
        }
    }
}
