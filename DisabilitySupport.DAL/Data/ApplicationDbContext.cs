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




    }
}
