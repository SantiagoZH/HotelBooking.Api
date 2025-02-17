using HotelBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HotelBooking.Infrastructure.Data
{
    public class HotelBookingDbContext : DbContext
    {
        public HotelBookingDbContext(DbContextOptions<HotelBookingDbContext> options)
            : base(options)
        {
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ✅ Relación: Un Hotel tiene muchas Reservaciones
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Hotel)
                .WithMany()
                .HasForeignKey(r => r.HotelId);

            // ✅ Relación: Una Room tiene muchas Reservaciones
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Room)
                .WithMany()
                .HasForeignKey(r => r.RoomId);

            // ✅ Relación Many-to-Many entre Reservation y Guest con tabla intermedia
            modelBuilder.Entity<Reservation>()
                .HasMany(r => r.Guests)
                .WithMany(g => g.Reservations)
                .UsingEntity<Dictionary<string, object>>(
                    "ReservationGuest", // Nombre de la tabla intermedia
                    j => j.HasOne<Guest>().WithMany().HasForeignKey("GuestId"),  // FK hacia Guest
                    j => j.HasOne<Reservation>().WithMany().HasForeignKey("ReservationId") // FK hacia Reservation
                );
        }
    }
}
