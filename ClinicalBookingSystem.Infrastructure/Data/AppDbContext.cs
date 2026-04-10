using ClinicalBookingSystem.Infrastructure.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ClinicalBookingSystem.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.UserId);
            base.OnModelCreating(modelBuilder);

            // Define a unique index on the username
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            // Defining the composite key (ClinicId, BookingDate, StartTime)
            modelBuilder.Entity<Booking>()
                .HasIndex(b => new { b.ClinicId, b.BookingDate, b.StartTime })
                .IsUnique();
        }
    }
}
