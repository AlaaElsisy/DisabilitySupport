using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilitySupport.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addServiceStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "HelperServices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "HelperServices",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "HelperServices");
        }
    }
}
