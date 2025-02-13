using HotelBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace HotelBooking.Infrastructure.Data;

public class HotelBookingDbContext : DbContext
{
    public HotelBookingDbContext(DbContextOptions<HotelBookingDbContext> options)
        : base(options)
    {
    }

    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Guest> Guests { get; set; }
    public DbSet<Reservation> Reservations { get; set; } // Agregar tabla de reservas

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Definir relaciones
        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Hotel)
            .WithMany()
            .HasForeignKey(r => r.HotelId);

        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Room)
            .WithMany()
            .HasForeignKey(r => r.RoomId);

        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Guest)
            .WithMany()
            .HasForeignKey(r => r.GuestId);
    }
}
