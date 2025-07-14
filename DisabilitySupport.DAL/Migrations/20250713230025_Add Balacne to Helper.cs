using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilitySupport.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddBalacnetoHelper : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "Helpers",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Helpers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Balance",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Helpers");
        }
    }
}
