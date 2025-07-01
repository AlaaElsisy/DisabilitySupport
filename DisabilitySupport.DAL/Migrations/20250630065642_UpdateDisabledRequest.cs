using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilitySupport.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDisabledRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "End",
                table: "DisabledRequests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Start",
                table: "DisabledRequests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "price",
                table: "DisabledRequests",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "DisabledOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "DisabledRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "End", "Start", "price" },
                values: new object[] { null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "End",
                table: "DisabledRequests");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "DisabledRequests");

            migrationBuilder.DropColumn(
                name: "price",
                table: "DisabledRequests");

            migrationBuilder.UpdateData(
                table: "DisabledOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 0);
        }
    }
}
