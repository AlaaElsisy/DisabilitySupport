using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DisabilitySupport.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ApplicationUser",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "CreatedAt", "DateOfBirth", "Email", "EmailConfirmed", "FullName", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImage", "SecurityStamp", "TwoFactorEnabled", "UserName", "Zone" },
                values: new object[,]
                {
                    { "2a3d9830-a243-4815-8ac3-917c222ca294", 0, null, "7a3f3df3-8ad7-4895-98a5-39310b926ada", null, null, "elsisyalaa0@gmail.com", false, "AlaaElsisy", null, true, null, "ELSISYALAA0@GMAIL.COM", "ALAAELSISY", "AQAAAAIAAYagAAAAEPlYF+M2akELjIIoTDDtq90WHNEeqahwPbJxZWXd/1+LjhddpGYl3EN1gEvBtKDDZA==", null, false, null, "5DBNFQNNIEM27IABAZQG2XURQSJC225I", false, "AlaaElsisy", null },
                    { "ADMIN-USER-001", 0, null, "STATIC-CONCURRENCY-STAMP-001", null, null, "admin@site.com", true, "Admin User", null, false, null, "ADMIN@SITE.COM", "ADMIN@SITE.COM", "AQAAAAIAAYagAAAAEIjJh6/LXD2Bg+3MJGc+CmiaE471FJWBEmlTQ/1OhqkFw0NIgG/beU7wkTfmnuQ/sQ==", null, false, null, "STATIC-SECURITY-STAMP-001", false, "admin@site.com", null }
                });

            migrationBuilder.InsertData(
                table: "ServiceCategories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Help with getting to appointments", "Transportation" },
                    { 2, "First aid or ongoing medical support", "Medical Aid" }
                });

            migrationBuilder.InsertData(
                table: "DisabledPeople",
                columns: new[] { "Id", "DisabilityType", "EmergencyContactName", "EmergencyContactPhone", "EmergencyContactRelation", "MedicalConditionDescription", "UserId" },
                values: new object[] { 1, "Mobility Impairment", "Ahmed Elsisy", "0123456789", "Brother", "Unable to walk long distances", "2a3d9830-a243-4815-8ac3-917c222ca294" });

            migrationBuilder.InsertData(
                table: "Helpers",
                columns: new[] { "Id", "Bio", "UserId" },
                values: new object[] { 1, "I have experience assisting people with mobility challenges.", "ADMIN-USER-001" });

            migrationBuilder.InsertData(
                table: "DisabledOffers",
                columns: new[] { "Id", "Budget", "Description", "DisabledId", "OfferPostDate", "ServiceCategorId", "ServiceTime", "Status" },
                values: new object[] { 1, 500m, "Need transportation to hospital every Monday", 1, new DateTime(2024, 6, 24, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2024, 6, 26, 14, 0, 0, 0, DateTimeKind.Unspecified), 0 });

            migrationBuilder.InsertData(
                table: "HelperServices",
                columns: new[] { "Id", "AvailableDateFrom", "AvailableDateTo", "CreatedAt", "Description", "HelperId", "PricePerHour", "ServiceCategoryId" },
                values: new object[] { 1, new DateTime(2024, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), "Transportation support", 1, 100m, 1 });

            migrationBuilder.InsertData(
                table: "DisabledRequests",
                columns: new[] { "Id", "Description", "DisabledId", "HelperServiceId", "RequestDate", "Status" },
                values: new object[] { 1, "Medical check-up request", 1, 1, new DateTime(2024, 6, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), 0 });

            migrationBuilder.InsertData(
                table: "HelperRequests",
                columns: new[] { "Id", "ApplicationDate", "DisabledOfferId", "HelperId", "Message", "Status", "TotalPrice" },
                values: new object[] { 1, new DateTime(2024, 6, 23, 15, 30, 0, 0, DateTimeKind.Unspecified), 1, 1, "I can help with transportation.", 0, 400m });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "Date", "DisabledRequestId", "HelperRequestId", "PaymentMethod", "Status" },
                values: new object[] { 1, 400m, new DateTime(2024, 6, 24, 18, 45, 0, 0, DateTimeKind.Unspecified), 1, 1, "Credit Card", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DisabledRequests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HelperRequests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DisabledOffers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HelperServices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DisabledPeople",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Helpers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "2a3d9830-a243-4815-8ac3-917c222ca294");

            migrationBuilder.DeleteData(
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "ADMIN-USER-001");
        }
    }
}
