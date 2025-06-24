using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DisabilitySupport.DAL.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
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
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
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
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_DisabledPeople_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
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
                        name: "FK_Helpers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
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
                    Budget = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
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
                    PricePerHour = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
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
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
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
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

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
                name: "AspNetUsers");
        }
    }
}
