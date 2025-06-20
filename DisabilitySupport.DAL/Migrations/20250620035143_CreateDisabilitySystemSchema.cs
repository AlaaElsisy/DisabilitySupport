using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilitySupport.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CreateDisabilitySystemSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    ProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DisabledPeople",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicalConditionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisabilityType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmergencyContactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmergencyContactPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmergencyContactRelation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisabledPeople", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DisabledPeople_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Helpers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Helpers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Helpers_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DisabledOffers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfferPostDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ServiceTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Budget = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DisabledId = table.Column<int>(type: "int", nullable: true),
                    ServiceCategorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisabledOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DisabledOffers_DisabledPeople_DisabledId",
                        column: x => x.DisabledId,
                        principalTable: "DisabledPeople",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DisabledOffers_ServiceCategories_ServiceCategorId",
                        column: x => x.ServiceCategorId,
                        principalTable: "ServiceCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HelperServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PricePerHour = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AvailableDateFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AvailableDateTo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HelperId = table.Column<int>(type: "int", nullable: true),
                    ServiceCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HelperServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HelperServices_Helpers_HelperId",
                        column: x => x.HelperId,
                        principalTable: "Helpers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HelperServices_ServiceCategories_ServiceCategoryId",
                        column: x => x.ServiceCategoryId,
                        principalTable: "ServiceCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HelperRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    HelperId = table.Column<int>(type: "int", nullable: true),
                    DisabledOfferId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HelperRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HelperRequests_DisabledOffers_DisabledOfferId",
                        column: x => x.DisabledOfferId,
                        principalTable: "DisabledOffers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HelperRequests_Helpers_HelperId",
                        column: x => x.HelperId,
                        principalTable: "Helpers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DisabledRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true),
                    DisabledId = table.Column<int>(type: "int", nullable: true),
                    HelperServiceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisabledRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DisabledRequests_DisabledPeople_DisabledId",
                        column: x => x.DisabledId,
                        principalTable: "DisabledPeople",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DisabledRequests_HelperServices_HelperServiceId",
                        column: x => x.HelperServiceId,
                        principalTable: "HelperServices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    HelperRequestId = table.Column<int>(type: "int", nullable: true),
                    DisabledRequestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_DisabledRequests_DisabledRequestId",
                        column: x => x.DisabledRequestId,
                        principalTable: "DisabledRequests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Payments_HelperRequests_HelperRequestId",
                        column: x => x.HelperRequestId,
                        principalTable: "HelperRequests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DisabledOffers_DisabledId",
                table: "DisabledOffers",
                column: "DisabledId");

            migrationBuilder.CreateIndex(
                name: "IX_DisabledOffers_ServiceCategorId",
                table: "DisabledOffers",
                column: "ServiceCategorId");

            migrationBuilder.CreateIndex(
                name: "IX_DisabledPeople_UserId",
                table: "DisabledPeople",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DisabledRequests_DisabledId",
                table: "DisabledRequests",
                column: "DisabledId");

            migrationBuilder.CreateIndex(
                name: "IX_DisabledRequests_HelperServiceId",
                table: "DisabledRequests",
                column: "HelperServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_HelperRequests_DisabledOfferId",
                table: "HelperRequests",
                column: "DisabledOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_HelperRequests_HelperId",
                table: "HelperRequests",
                column: "HelperId");

            migrationBuilder.CreateIndex(
                name: "IX_Helpers_UserId",
                table: "Helpers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HelperServices_HelperId",
                table: "HelperServices",
                column: "HelperId");

            migrationBuilder.CreateIndex(
                name: "IX_HelperServices_ServiceCategoryId",
                table: "HelperServices",
                column: "ServiceCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_DisabledRequestId",
                table: "Payments",
                column: "DisabledRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_HelperRequestId",
                table: "Payments",
                column: "HelperRequestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "DisabledRequests");

            migrationBuilder.DropTable(
                name: "HelperRequests");

            migrationBuilder.DropTable(
                name: "HelperServices");

            migrationBuilder.DropTable(
                name: "DisabledOffers");

            migrationBuilder.DropTable(
                name: "Helpers");

            migrationBuilder.DropTable(
                name: "DisabledPeople");

            migrationBuilder.DropTable(
                name: "ServiceCategories");

            migrationBuilder.DropTable(
                name: "ApplicationUser");
        }
    }
}
