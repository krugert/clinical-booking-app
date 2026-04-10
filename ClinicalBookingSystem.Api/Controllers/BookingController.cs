using ClinicalBookingSystem.Infrastructure.Interfaces;
using ClinicalBookingSystem.Infrastructure.Models.DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ClinicalBookingSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IValidator<BookingDto> _validator;

        public BookingController(IBookingService bookingService, IValidator<BookingDto> validator)
        {
            _bookingService = bookingService;
            _validator = validator;
        }

        [HttpPost("create-booking")]
        public async Task<IActionResult> CreateBooking(BookingDto request)
        {
            var validation = await _validator.ValidateAsync(request);
            if (!validation.IsValid)
                return BadRequest(validation.Errors);

            try
            {
                await _bookingService.CreateBookingAsync(request);
                return Ok(new { message = "Booking created successfully." });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { error = ex.Message });
            }
        }
    }
}
