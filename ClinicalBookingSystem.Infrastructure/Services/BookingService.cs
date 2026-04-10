using ClinicalBookingSystem.Infrastructure.Data;
using ClinicalBookingSystem.Infrastructure.Interfaces;
using ClinicalBookingSystem.Infrastructure.Models.Domain;
using ClinicalBookingSystem.Infrastructure.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ClinicalBookingSystem.App.Services
{
    public class BookingService : IBookingService
    {
        private readonly AppDbContext _context;

        public BookingService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateBookingAsync(BookingDto request)
        {
            if (await IsDoubleBookingAsync(request))
            {
                throw new InvalidOperationException("A booking already exists for this date and time.");
            }
            else if (await InvalidBookingDateTimeAsync(request))
            {
                throw new InvalidOperationException("Invalid booking date or time.");
            }

            var booking = new Booking
            {
                PatientId = request.PatientId,
                ClinicId = request.ClinicId,
                BookingDate = request.BookingDate,
                StartTime = request.StartTime
            };

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsDoubleBookingAsync(BookingDto request)
        {
            return await _context.Bookings.AnyAsync(b =>
                b.ClinicId == request.ClinicId &&
                b.BookingDate == request.BookingDate &&
                b.StartTime == request.StartTime);
        }

        public async Task<bool> InvalidBookingDateTimeAsync(BookingDto request)
        {
            return await _context.Bookings.AnyAsync(b =>
                b.BookingDate < request.BookingDate ||
                b.StartTime <= request.StartTime);
        }
    }
}
