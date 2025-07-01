
using System;
using DisabilitySupport.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DisabilitySupport.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DisabilitySupport.DAL.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Zone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "2a3d9830-a243-4815-8ac3-917c222ca294",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7a3f3df3-8ad7-4895-98a5-39310b926ada",
                            Email = "elsisyalaa0@gmail.com",
                            EmailConfirmed = false,
                            FullName = "AlaaElsisy",
                            LockoutEnabled = true,
                            NormalizedEmail = "ELSISYALAA0@GMAIL.COM",
                            NormalizedUserName = "ALAAELSISY",
                            PasswordHash = "AQAAAAIAAYagAAAAEPlYF+M2akELjIIoTDDtq90WHNEeqahwPbJxZWXd/1+LjhddpGYl3EN1gEvBtKDDZA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "5DBNFQNNIEM27IABAZQG2XURQSJC225I",
                            TwoFactorEnabled = false,
                            UserName = "AlaaElsisy"
                        },
                        new
                        {
                            Id = "ADMIN-USER-001",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "STATIC-CONCURRENCY-STAMP-001",
                            Email = "admin@site.com",
                            EmailConfirmed = true,
                            FullName = "Admin User",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@SITE.COM",
                            NormalizedUserName = "ADMIN@SITE.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEIjJh6/LXD2Bg+3MJGc+CmiaE471FJWBEmlTQ/1OhqkFw0NIgG/beU7wkTfmnuQ/sQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "STATIC-SECURITY-STAMP-001",
                            TwoFactorEnabled = false,
                            UserName = "admin@site.com"
                        });
                });

            modelBuilder.Entity("DisabilitySupport.DAL.Models.Disabled", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DisabilityType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmergencyContactName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmergencyContactPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmergencyContactRelation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MedicalConditionDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("DisabledPeople");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisabilityType = "Mobility Impairment",
                            EmergencyContactName = "Ahmed Elsisy",
                            EmergencyContactPhone = "0123456789",
                            EmergencyContactRelation = "Brother",
                            MedicalConditionDescription = "Unable to walk long distances",
                            UserId = "2a3d9830-a243-4815-8ac3-917c222ca294"
                        });
                });

            modelBuilder.Entity("DisabilitySupport.DAL.Models.DisabledOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal?>("Budget")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DisabledId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndServiceTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OfferPostDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ServiceCategorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartServiceTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DisabledId");

                    b.HasIndex("ServiceCategorId");

                    b.ToTable("DisabledOffers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Budget = 500m,
                            Description = "Need transportation to hospital every Monday",
                            DisabledId = 1,
                            EndServiceTime = new DateTime(2024, 6, 27, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            OfferPostDate = new DateTime(2024, 6, 24, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            ServiceCategorId = 1,

                            StartServiceTime = new DateTime(2024, 6, 26, 14, 0, 0, 0, DateTimeKind.Unspecified),

                            Status = 1
                        });
                });

            modelBuilder.Entity("DisabilitySupport.DAL.Models.DisabledRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DisabledId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("End")
                        .HasColumnType("datetime2");

                    b.Property<int?>("HelperServiceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Start")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<decimal?>("price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("DisabledId");

                    b.HasIndex("HelperServiceId");

                    b.ToTable("DisabledRequests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Medical check-up request",
                            DisabledId = 1,
                            HelperServiceId = 1,
                            RequestDate = new DateTime(2024, 6, 21, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = 0
                        });
                });

            modelBuilder.Entity("DisabilitySupport.DAL.Models.Helper", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Helpers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Bio = "I have experience assisting people with mobility challenges.",
                            UserId = "ADMIN-USER-001"
                        });
                });

            modelBuilder.Entity("DisabilitySupport.DAL.Models.HelperRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ApplicationDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DisabledOfferId")
                        .HasColumnType("int");

                    b.Property<int?>("HelperId")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal?>("TotalPrice")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("DisabledOfferId");

                    b.HasIndex("HelperId");

                    b.ToTable("HelperRequests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ApplicationDate = new DateTime(2024, 6, 23, 15, 30, 0, 0, DateTimeKind.Unspecified),
                            DisabledOfferId = 1,
                            HelperId = 1,
                            Message = "I can help with transportation.",
                            Status = 0,
                            TotalPrice = 400m
                        });
                });

            modelBuilder.Entity("DisabilitySupport.DAL.Models.HelperService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("AvailableDateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("AvailableDateTo")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HelperId")
                        .HasColumnType("int");

                    b.Property<decimal?>("PricePerHour")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ServiceCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HelperId");

                    b.HasIndex("ServiceCategoryId");

                    b.ToTable("HelperServices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AvailableDateFrom = new DateTime(2024, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            AvailableDateTo = new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedAt = new DateTime(2024, 6, 20, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Transportation support",
                            HelperId = 1,
                            PricePerHour = 100m,
                            ServiceCategoryId = 1
                        });
                });

            modelBuilder.Entity("DisabilitySupport.DAL.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DisabledRequestId")
                        .HasColumnType("int");

                    b.Property<int?>("HelperRequestId")
                        .HasColumnType("int");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DisabledRequestId");

                    b.HasIndex("HelperRequestId");

                    b.ToTable("Payments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 400m,
                            Date = new DateTime(2024, 6, 24, 18, 45, 0, 0, DateTimeKind.Unspecified),
                            DisabledRequestId = 1,
                            HelperRequestId = 1,
                            PaymentMethod = "Credit Card",
                            Status = 1
                        });
                });

            modelBuilder.Entity("DisabilitySupport.DAL.Models.ServiceCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ServiceCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Help with getting to appointments",
                            Name = "Transportation"
                        },
                        new
                        {
                            Id = 2,
                            Description = "First aid or ongoing medical support",
                            Name = "Medical Aid"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("DisabilitySupport.DAL.Models.Disabled", b =>
                {
                    b.HasOne("DisabilitySupport.DAL.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DisabilitySupport.DAL.Models.DisabledOffer", b =>
                {
                    b.HasOne("DisabilitySupport.DAL.Models.Disabled", "Disabled")
                        .WithMany("DisabledOffers")
                        .HasForeignKey("DisabledId");

                    b.HasOne("DisabilitySupport.DAL.Models.ServiceCategory", "ServiceCategory")
                        .WithMany("DisabledOffers")
                        .HasForeignKey("ServiceCategorId");

                    b.Navigation("Disabled");

                    b.Navigation("ServiceCategory");
                });

            modelBuilder.Entity("DisabilitySupport.DAL.Models.DisabledRequest", b =>
                {
                    b.HasOne("DisabilitySupport.DAL.Models.Disabled", "Disabled")
                        .WithMany("DisabledRequests")
                        .HasForeignKey("DisabledId");

                    b.HasOne("DisabilitySupport.DAL.Models.HelperService", "HelperService")
                        .WithMany("DisabledRequests")
                        .HasForeignKey("HelperServiceId");

                    b.Navigation("Disabled");

                    b.Navigation("HelperService");
                });

            modelBuilder.Entity("DisabilitySupport.DAL.Models.Helper", b =>
                {
                    b.HasOne("DisabilitySupport.DAL.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DisabilitySupport.DAL.Models.HelperRequest", b =>
                {
                    b.HasOne("DisabilitySupport.DAL.Models.DisabledOffer", "DisabledOffer")
                        .WithMany()
                        .HasForeignKey("DisabledOfferId");

                    b.HasOne("DisabilitySupport.DAL.Models.Helper", "Helper")
                        .WithMany("HelperRequests")
                        .HasForeignKey("HelperId");

                    b.Navigation("DisabledOffer");

                    b.Navigation("Helper");
                });

            modelBuilder.Entity("DisabilitySupport.DAL.Models.HelperService", b =>
                {
                    b.HasOne("DisabilitySupport.DAL.Models.Helper", "Helper")
                        .WithMany("HelperServices")
                        .HasForeignKey("HelperId");

                    b.HasOne("DisabilitySupport.DAL.Models.ServiceCategory", "ServiceCategory")
                        .WithMany("HelperServices")
                        .HasForeignKey("ServiceCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Helper");

                    b.Navigation("ServiceCategory");
                });

            modelBuilder.Entity("DisabilitySupport.DAL.Models.Payment", b =>
                {
                    b.HasOne("DisabilitySupport.DAL.Models.DisabledRequest", "DisabledRequest")
                        .WithMany()
                        .HasForeignKey("DisabledRequestId");

                    b.HasOne("DisabilitySupport.DAL.Models.HelperRequest", "HelperRequest")
                        .WithMany()
                        .HasForeignKey("HelperRequestId");

                    b.Navigation("DisabledRequest");

                    b.Navigation("HelperRequest");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DisabilitySupport.DAL.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DisabilitySupport.DAL.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DisabilitySupport.DAL.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DisabilitySupport.DAL.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DisabilitySupport.DAL.Models.Disabled", b =>
                {
                    b.Navigation("DisabledOffers");

                    b.Navigation("DisabledRequests");
                });

            modelBuilder.Entity("DisabilitySupport.DAL.Models.Helper", b =>
                {
                    b.Navigation("HelperRequests");

                    b.Navigation("HelperServices");
                });

            modelBuilder.Entity("DisabilitySupport.DAL.Models.HelperService", b =>
                {
                    b.Navigation("DisabledRequests");
                });

            modelBuilder.Entity("DisabilitySupport.DAL.Models.ServiceCategory", b =>
                {
                    b.Navigation("DisabledOffers");

                    b.Navigation("HelperServices");
                });
#pragma warning restore 612, 618
        }
    }
}
