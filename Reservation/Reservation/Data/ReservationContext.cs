using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reservation.Data.Tables;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.Arm;

namespace Reservation.Data
{
    public class ReservationContext : DbContext
    {
        public ReservationContext (DbContextOptions<ReservationContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole<string>>().HasNoKey();

        }

        public DbSet<User> User { get; set; }
        public DbSet<IdentityUserClaim<string>> claims { get; set; }
        public DbSet<IdentityUserRole<string>> roles { get; set; }
        public DbSet<IdentityRole> role { get; set; }
    }
}
