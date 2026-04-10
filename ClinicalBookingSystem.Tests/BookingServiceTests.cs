using ClinicalBookingSystem.App.Services;
using ClinicalBookingSystem.Infrastructure.Data;
using ClinicalBookingSystem.Infrastructure.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ClinicalBookingSystem.Tests
{
    public class BookingServiceTests
    {
        private BookingService CreateServiceWithInMemoryDb(out AppDbContext context)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            context = new AppDbContext(options);
            return new BookingService(context);
        }

        [Fact]
        public async Task IsDoubleBooking_ReturnsTrue_WhenBookingExists()
        {
            // Arrange
            var service = CreateServiceWithInMemoryDb(out var context);

            context.Bookings.Add(new ClinicalBookingSystem.Infrastructure.Models.Domain.Booking
            {
                PatientId = 1,
                ClinicId = 1,
                BookingDate = new DateOnly(2025, 1, 1),
                StartTime = new TimeOnly(9, 0)
            });
            await context.SaveChangesAsync();

            var booking = new BookingDto
            {
                PatientId = 2,
                ClinicId = 1,
                BookingDate = new DateOnly(2025, 1, 1),
                StartTime = new TimeOnly(9, 0)
            };

            // Act
            var result = await service.IsDoubleBookingAsync(booking);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task IsDoubleBooking_ReturnsFalse_WhenBookingDoesNotExist()
        {
            var service = CreateServiceWithInMemoryDb(out _);

            var dto = new BookingDto
            {
                PatientId = 1,
                ClinicId = 1,
                BookingDate = new DateOnly(2026, 2, 2),
                StartTime = new TimeOnly(10, 0)
            };

            var result = await service.IsDoubleBookingAsync(dto);
            Assert.False(result);
        }
    }
}
