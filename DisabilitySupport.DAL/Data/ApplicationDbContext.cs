using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisabilitySupport.DAL.Models;
using DisabilitySupport.DAL.Models.Enumerations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DisabilitySupport.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Disabled>? DisabledPeople { get; set; }
        public virtual DbSet<Helper>? Helpers { get; set; }
        public virtual DbSet<HelperService>? HelperServices { get; set; }
        public virtual DbSet<DisabledRequest>? DisabledRequests { get; set; }
        public virtual DbSet<DisabledOffer>? DisabledOffers { get; set; }
        public virtual DbSet<HelperRequest>? HelperRequests { get; set; }
        public virtual DbSet<Payment>? Payments { get; set; }
        public virtual DbSet<ServiceCategory> ServiceCategories { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DisabledOffer>()
    .Property(d => d.Budget)
    .HasPrecision(18, 2);

            modelBuilder.Entity<HelperRequest>()
                .Property(h => h.TotalPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<HelperService>()
                .Property(h => h.PricePerHour)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasPrecision(18, 2);


            // Seed ApplicationUser
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "2a3d9830-a243-4815-8ac3-917c222ca294",
                    FullName = "AlaaElsisy",
                    UserName = "AlaaElsisy",
                    NormalizedUserName = "ALAAELSISY",
                    Email = "elsisyalaa0@gmail.com",
                    NormalizedEmail = "ELSISYALAA0@GMAIL.COM",
                    EmailConfirmed = false,
                    PasswordHash = "AQAAAAIAAYagAAAAEPlYF+M2akELjIIoTDDtq90WHNEeqahwPbJxZWXd/1+LjhddpGYl3EN1gEvBtKDDZA==",
                    SecurityStamp = "5DBNFQNNIEM27IABAZQG2XURQSJC225I",
                    ConcurrencyStamp = "7a3f3df3-8ad7-4895-98a5-39310b926ada",
                    LockoutEnabled = true
                },
                new ApplicationUser
                {
                    Id = "ADMIN-USER-001",
                    FullName = "Admin User",
                    UserName = "admin@site.com",
                    NormalizedUserName = "ADMIN@SITE.COM",
                    Email = "admin@site.com",
                    NormalizedEmail = "ADMIN@SITE.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEIjJh6/LXD2Bg+3MJGc+CmiaE471FJWBEmlTQ/1OhqkFw0NIgG/beU7wkTfmnuQ/sQ==",
                    SecurityStamp = "STATIC-SECURITY-STAMP-001",
                    ConcurrencyStamp = "STATIC-CONCURRENCY-STAMP-001",
                    LockoutEnabled = false
                }
            );

            // Seed Disabled
            modelBuilder.Entity<Disabled>().HasData(new Disabled
            {
                Id = 1,
                UserId = "2a3d9830-a243-4815-8ac3-917c222ca294",
                DisabilityType = "Mobility Impairment",
                MedicalConditionDescription = "Unable to walk long distances",
                EmergencyContactName = "Ahmed Elsisy",
                EmergencyContactPhone = "0123456789",
                EmergencyContactRelation = "Brother"
            });

            // Seed Helper
            modelBuilder.Entity<Helper>().HasData(new Helper
            {
                Id = 1,
                UserId = "ADMIN-USER-001",
                Bio = "I have experience assisting people with mobility challenges."
            });

            // Seed ServiceCategory
            modelBuilder.Entity<ServiceCategory>().HasData(
                new ServiceCategory { Id = 1, Name = "Medical Service", Description = "Access to healthcare professionals and medical assistance.", Image = "Services Categories/MedicalService.png" },
                new ServiceCategory { Id = 2, Name = "Driver Service", Description = "Transportation assistance for individuals with disabilities, ensuring safe and accessible travel.", Image = "Services Categories/DriverService.png" },
                new ServiceCategory { Id = 3, Name = "Public Service", Description = "Assistance with navigating public services and resources.", Image = "Services Categories/PublicService.png" },
                new ServiceCategory { Id = 4, Name = "Delivery Service", Description = "Reliable delivery services for essential items and groceries.", Image = "" }
            );

            // Seed DisabledOffer
            modelBuilder.Entity<DisabledOffer>().HasData(new DisabledOffer
            {
                Id = 1,
                Description = "Need transportation to hospital every Monday",
                OfferPostDate = new DateTime(2024, 06, 24, 12, 0, 0),
                Status = Models.Enumerations.DisabledOfferStatus.Open,
                Budget = 500,
                DisabledId = 1,
                ServiceCategorId = 1,
                StartServiceTime = new DateTime(2024, 06, 26, 14, 0, 0),
                EndServiceTime = new DateTime(2024, 06, 27, 15, 0, 0)
            });

            // Seed DisabledRequest
            modelBuilder.Entity<DisabledRequest>().HasData(new DisabledRequest
            {
                Id = 1,
                Description = "Medical check-up request",
                RequestDate = new DateTime(2024, 06, 21, 09, 0, 0),
                Status = Models.Enumerations.RequestStatus.Pending,
                DisabledId = 1,
                HelperServiceId = 1
            });

            // Seed HelperService
            modelBuilder.Entity<HelperService>().HasData(new HelperService
            {
                Id = 1,
                Description = "Transportation support",
                PricePerHour = 100,
                CreatedAt = new DateTime(2024, 06, 20, 08, 0, 0),
                AvailableDateFrom = new DateTime(2024, 06, 25),
                AvailableDateTo = new DateTime(2024, 07, 05),
                HelperId = 1,
                ServiceCategoryId = 1
            });

            // Seed HelperRequest
            modelBuilder.Entity<HelperRequest>().HasData(new HelperRequest
            {
                Id = 1,
                ApplicationDate = new DateTime(2024, 06, 23, 15, 30, 0),
                Status = Models.Enumerations.HelperRequestStatus.Pending,
                Message = "I can help with transportation.",
                TotalPrice = 400,
                HelperId = 1,
                DisabledOfferId = 1
            });

            // Seed Payment
            modelBuilder.Entity<Payment>().HasData(new Payment
            {
                Id = 1,
                Amount = 400,
                Date = new DateTime(2024, 06, 24, 18, 45, 0),
                PaymentMethod = "Credit Card",
                Status = Models.Enumerations.PaymentStatus.Paid,
                HelperRequestId = 1,
                DisabledRequestId = 1
            });
        }



    }
}
