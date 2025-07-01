using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilitySupport.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updatedisaplyedOffer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ServiceTime",
                table: "DisabledOffers",
                newName: "StartServiceTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndServiceTime",
                table: "DisabledOffers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "DisabledOffers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndServiceTime", "Status" },
                values: new object[] { new DateTime(2024, 6, 27, 15, 0, 0, 0, DateTimeKind.Unspecified), 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndServiceTime",
                table: "DisabledOffers");

            migrationBuilder.RenameColumn(
                name: "StartServiceTime",
                table: "DisabledOffers",
                newName: "ServiceTime");

            migrationBuilder.UpdateData(
                table: "DisabledOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 0);
        }
    }
}
