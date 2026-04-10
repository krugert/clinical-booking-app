using ClinicalBookingSystem.Infrastructure.Models.DTOs;

namespace ClinicalBookingSystem.Infrastructure.Interfaces
{
    public interface IBookingService
    {
        Task CreateBookingAsync(BookingDto request);
        Task<bool> IsDoubleBookingAsync(BookingDto request);
        Task<bool> InvalidBookingDateTimeAsync(BookingDto request);
    }
}
