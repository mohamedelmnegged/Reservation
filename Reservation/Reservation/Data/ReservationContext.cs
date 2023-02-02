using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reservation.Data.Tables;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Reservation.Data
{
    public class ReservationContext : DbContext
    {
        public ReservationContext (DbContextOptions<ReservationContext> options)
            : base(options)
        {
        }

        public DbSet<Reservation.Data.Tables.User> User { get; set; } = default!;
    }
}
