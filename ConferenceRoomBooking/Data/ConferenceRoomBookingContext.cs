using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ConferenceRoomBooking.Models;

namespace ConferenceRoomBooking.Data
{
    public class ConferenceRoomBookingContext : DbContext
    {
        public ConferenceRoomBookingContext (DbContextOptions<ConferenceRoomBookingContext> options)
            : base(options)
        {
        }

        public DbSet<ConferenceRoomBooking.Models.User> User { get; set; }

        public DbSet<ConferenceRoomBooking.Models.Room> Room { get; set; }

        public DbSet<ConferenceRoomBooking.Models.Reservation> Reservation { get; set; }
    }
}
